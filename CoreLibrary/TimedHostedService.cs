using CoreLibrary;
using CoreLibrary.Notifications;
using Data;
using Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CoreLibrary
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;
        public TimedHostedService(IServiceScopeFactory scopeFactory, ILogger<TimedHostedService> logger)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var _dbcontext = scope.ServiceProvider.GetRequiredService<DataContext>();
                try
                {
                    // 10 dakika kalan doktorlara bildirim
                    List<int> doctors = _dbcontext.Appointment.Where(x => !x.IsDeleted && x.UserId != 1 && x.AppointmentDate >= DateTime.Now.AddMinutes(10) && x.AppointmentDate <= DateTime.Now.AddMinutes(12)).Select(x => x.DoctorId).ToList();
                    NotificationSender sendNotify = new NotificationSender();
                    if (doctors.Count > 0)
                    {
                        var response = sendNotify.SendNotificationAsync(new NotificationPostData()
                        {
                            FcmTokens = _dbcontext.NotifyTokens.Where(x => doctors.Contains(x.UserId)).Select(x => x.Token).ToList(),
                            MessageData = new NotificationMessageData() { Title = "Randevunuz Yaklaştı", Message = "Randevunuzun Başlamasına Son 10 Dakika Kalmıştır.", Link = "", Action = "", Image = "https://www.doctorla.co/images/logo.png" }
                        });

                        _dbcontext.Appointment.Where(x => x.AppointmentFinishDate < DateTime.Now && x.Status == 0).ToList().ForEach(x => x.Status = 1);
                        _dbcontext.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    _dbcontext.Logs.Add(new Logs()
                    {
                        ErrorMessage = "Appointment Error - Timer Host Service Error:" + ex.ToString(),
                        IDate = DateTime.Now,
                        LogType = 1,
                        Page = "Timer Hosted"
                    });
                    _dbcontext.SaveChanges();
                }

                try
                {
                    // Dailychecks
                    List<DailyCheckAlerts> pastdailychecks = _dbcontext.DailyCheckAlerts.Include(x => x.DailyCheck).Where(x => x.DailyCheck.Finish >= DateTime.Now).ToList();
                    foreach (var item in pastdailychecks.Where(x => x.AlertDay <= DateTime.Now).ToList())
                        item.AlertDay = item.AlertDay != null ? item.AlertDay.AddDays(item.DayCounter) : DateTime.Now.AddDays(item.DayCounter);

                    foreach (var item in pastdailychecks.Where(x => x.AlertDay >= DateTime.Now && x.AlertDay <= DateTime.Now.AddMinutes(5)))
                    {
                        User user = _dbcontext.User.FirstOrDefault(x => x.Id == item.DailyCheck.UserId);
                        if (user != null)
                            if (!String.IsNullOrEmpty(user.Phone))
                                SmsServices.SendSms(user.Phone, "Hatirlatma: " + item.Message + "..\n Doctorla ");
                        //if (!String.IsNullOrEmpty(item.DailyCheck.ExtraPhone))
                        //    SmsServices.SendSms(item.DailyCheck.ExtraPhone, "Hatirlatma: " + item.Message + "..\n Doctorla ");
                        item.AlertDay = item.AlertDay.AddDays(item.DayCounter);
                    }
                    _dbcontext.SaveChanges();

                }
                catch (Exception ex)
                {
                    _dbcontext.Logs.Add(new Logs()
                    {
                        ErrorMessage = "DailyCheck Error - Timer Host SErvice ERror:" + ex.ToString(),
                        IDate = DateTime.Now,
                        LogType = 1,
                        Page = "Timer Hosted"
                    });
                    _dbcontext.SaveChanges();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
