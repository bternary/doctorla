using Data.Domain;
using Domain.Interfaces.Base;
using Domain.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Data.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces.Repositories;
using Services.Models;
using System.IO;
using Domain.Interfaces;

namespace Services
{
    public class DailyCheckService : Service<DailyCheckAlerts>, IDailyCheckService
    {
        private readonly IRepository<DailyCheck> _dailyCheckRepostory;
        private readonly IRepository<DailyCheckDetail> _dailyCheckDetailRepostory;
        private readonly IRepository<DailyCheckDetailValues> _dailyCheckDetailValuesRepostory;
        private readonly ISettingsHelper _settingsHelper;
        private readonly IRepository<PackageChat> _packageChatRepostory;
        public DailyCheckService(IRepository<DailyCheckAlerts> repository
            , IRepository<DailyCheck> dailyCheckRepostory
            , IRepository<DailyCheckDetail> dailyCheckDetailRepostory
            , IRepository<DailyCheckDetailValues> dailyCheckDetailValuesRepostory
            , ISettingsHelper settingsHelper
            , IRepository<PackageChat> packageChatRepostory
            ) : base(repository)
        {
            _dailyCheckDetailRepostory = dailyCheckDetailRepostory;
            _dailyCheckDetailValuesRepostory = dailyCheckDetailValuesRepostory;
            _dailyCheckRepostory = dailyCheckRepostory;
            _settingsHelper = settingsHelper;
            _packageChatRepostory = packageChatRepostory;
        }
        public GenericServiceListModel<DailyCheckAlerts> GetAlerts(int userId, int daylycheckId, SortingPagingInfo sorting)
        {
            return GetItems(sorting, "DailyCheck", p => (p.DailyCheck.UserId == userId || p.DailyCheck.NurseId == userId) && p.DailyCheck.Id == daylycheckId);
        }
        public bool Save(DailyCheckAlerts alert)
        {
            var result = false;
            if (alert.Id > 0)
                result = _repository.Update(alert);
            else
                result = _repository.Add(alert);
            return result;
        }
        public bool Delete(int dailycheckAlertId)
        {
            return _repository.RemoveById(dailycheckAlertId);
        }
        public (bool, string) CreateDailyCheckDetail(int userId, int dailyCheckId, List<DailyCheckValues> values, List<FileReqModel> files)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            if (dailyCheckId == 0 && _dailyCheckRepostory.FirstOrDefault(x => x.Id == dailyCheckId).UserId != userId)
                result.Item2 = "Lütfen Değerleri Giriniz";
            else
            {
                DailyCheck dailycheck = _dailyCheckRepostory.Where(x => x.Id == dailyCheckId).Include(x => x.User).Include(x => x.DailyCheckDetail).FirstOrDefault();
                Random rnd = new Random();
                string detailvaluecode = rnd.Next(100000, 999999).ToString();

                foreach (var item in dailycheck.DailyCheckDetail)
                {
                    if (item.TitleOrder != 1102)
                    {
                        DailyCheckDetailValues dailyCheckDetail = new DailyCheckDetailValues()
                        {
                            DailyCheckDetailId = item.Id,
                            TitleOrder = item.TitleOrder,
                            Value = values.FirstOrDefault(x => x.DailyCheckDetailId == item.Id) != null ? values.FirstOrDefault(x => x.DailyCheckDetailId == item.Id).Value : "",
                            IDate = DateTime.Now,
                            Key = detailvaluecode
                        };
                        _dailyCheckDetailValuesRepostory.Add(dailyCheckDetail);
                    }
                }
                int dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1100).Id;
                if (values.FirstOrDefault(x => x.DailyCheckDetailId == dailycheckfileid) == null)
                {
                    DailyCheckDetailValues hastanot = new DailyCheckDetailValues()
                    {
                        DailyCheckDetailId = dailycheckfileid,
                        TitleOrder = 1100,
                        Value = "",
                        IDate = DateTime.Now,
                        Key = detailvaluecode
                    };
                    _dailyCheckDetailValuesRepostory.Add(hastanot);
                }
                dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1101).Id;
                if (values.FirstOrDefault(x => x.DailyCheckDetailId == dailycheckfileid) == null)
                {
                    DailyCheckDetailValues hemsirenot = new DailyCheckDetailValues()
                    {
                        DailyCheckDetailId = dailycheckfileid,
                        TitleOrder = 1101,
                        Value = "",
                        IDate = DateTime.Now,
                        Key = detailvaluecode
                    };
                    _dailyCheckDetailValuesRepostory.Add(hemsirenot);
                }
                string filenames = "";
                if (files != null && files.Count > 0)
                {
                    foreach (var detailfile in files)
                    {
                        if (!String.IsNullOrEmpty(detailfile.FileName))
                        {
                            string filename = Guid.NewGuid().ToString() + "-" + dailycheck.User.Name + "_" + dailycheck.User.SurName;
                            if (detailfile.FileName.Contains("pdf"))
                                filename += ".pdf";
                            else if (detailfile.FileName.Contains("word"))
                                filename += ".docx";
                            else if (detailfile.FileName.Contains("sheet"))
                                filename += ".xlsx";
                            else if (detailfile.FileName.Contains("png") || detailfile.FileName.Contains("jpg") || detailfile.FileName.Contains("jpeg"))
                                filename += ".png";
                            else
                                continue;
                            var basePath = Path.Combine(_settingsHelper.GetSetting("BaseFileDirectory"), "DailyCheckFiles");
                            var filePath = Path.Combine(basePath, filename);
                            var bytes = Convert.FromBase64String(detailfile.FileData);
                            using (var File = new FileStream(filePath, FileMode.Create))
                            {
                                File.Write(bytes, 0, bytes.Length);
                                File.Flush();
                            }
                            filenames += filename + ",";
                        }
                    }
                    filenames = filenames.Remove(filenames.Length - 1);
                }
                dailycheckfileid = dailycheck.DailyCheckDetail.FirstOrDefault(x => x.TitleOrder == 1102).Id;
                DailyCheckDetailValues filevalue = new DailyCheckDetailValues()
                {
                    DailyCheckDetailId = dailycheckfileid,
                    TitleOrder = 1102,
                    Value = filenames,
                    IDate = DateTime.Now,
                    Key = detailvaluecode
                };
                _dailyCheckDetailValuesRepostory.Add(filevalue);
                dailycheck.IsNewData = true;
                result.Item1 = true;
                result.Item2 = "Değerleriniz Başarılı Bir Şekilde Eklendi";
            }
            return result;
        }
        public List<DailyCheckDetail> GetDailyCheckDetails(int userId, int dailyCheckId, string filter = "")
        {
            var result = new List<DailyCheckDetail>();
            DailyCheck package = _dailyCheckRepostory.FirstOrDefault(x => x.Id == dailyCheckId && x.UserId == userId);
            if (package != null)
            {
                Expression<Func<DailyCheckDetail, bool>> Filter = (p => p.DailyCheckId == dailyCheckId);
                if (!string.IsNullOrEmpty(filter))
                {
                    var splitFilter = filter.Split(',', StringSplitOptions.RemoveEmptyEntries);
                    List<int> orders = splitFilter.Select(p => Convert.ToInt32(p)).ToList();
                    Filter = Filter.AndAlso(p => orders.Any(x => x == p.TitleOrder));
                }
                result = _dailyCheckDetailRepostory.Where(Filter).Include(x => x.DailyCheck).Include(x => x.ValuesTitle).Include(x => x.Values).ToList();
            }
            return result;
        }
        public List<PackageChat> GetChatList(int dailyCheckId)
        {
            return _packageChatRepostory.Where(p => p.DailyCheckId == dailyCheckId).OrderBy(p => p.Date).ToList();
        }
        public bool SendChat(int dailyCheckId, string message, FileReqModel file, bool isDoctor)
        {
            var result = true;
            try
            {
                var isFile = false;
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    string filename = Guid.NewGuid().ToString() + "-" + dailyCheckId;
                    if (file.FileName.Contains("pdf"))
                        filename += ".pdf";
                    else if (file.FileName.Contains("word"))
                        filename += ".docx";
                    else if (file.FileName.Contains("sheet"))
                        filename += ".xlsx";
                    else if (file.FileName.Contains("png") || file.FileName.Contains("jpg") || file.FileName.Contains("jpeg"))
                        filename += ".png";
                    var basePath = Path.Combine(_settingsHelper.GetSetting("BaseFileDirectory"), "DailyCheckFiles");
                    var filePath = Path.Combine(basePath, filename);
                    var bytes = Convert.FromBase64String(file.FileData);
                    using (var File = new FileStream(filePath, FileMode.Create))
                    {
                        File.Write(bytes, 0, bytes.Length);
                        File.Flush();
                    }
                    isFile = true;
                    message = filename;
                }
                PackageChat packageChat = new PackageChat()
                {
                    Message = message,
                    Date = DateTime.Now,
                    DailyCheckId = dailyCheckId,
                    IsDoctor = isDoctor,
                    IsFile = isFile,
                };
                _packageChatRepostory.Add(packageChat);
            }
            catch (Exception)
            {

                result = false;
            }
            return result;
        }
        public GenericServiceListModel<DailyCheck> GetUserDailyChecks(int userId, SortingPagingInfo sorting)
        {
            var result = new GenericServiceListModel<DailyCheck>();
            var query = _dailyCheckRepostory.Where(p => p.UserId == userId && p.IsDeleted == false)
                .Include(p => p.User)
                .Include(p => p.Nurse)
                .OrderBy(!string.IsNullOrEmpty(sorting.SortField) ? sorting.SortField : "Id", sorting.SortDirection);
            result.TotalCount = query.Count();
            result.CurrentPage = sorting.PageIndex;
            if (sorting.PageIndex == 0)
            {
                result.PageSize = result.TotalCount;
                result.Items = query.ToList();
            }
            else
            {
                result.PageSize = sorting.PageSize;
                result.Items = query.Skip(sorting.PageSize * (sorting.PageIndex - 1))
              .Take(sorting.PageSize);
            }
            return result;

        }
    }
}
