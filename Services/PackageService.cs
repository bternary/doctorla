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
using Domain.Enums;

namespace Services
{
    public class PackageService : Service<Package>, IPackageService
    {
        private readonly IUserService _userRepository;
        private readonly IRepository<DailyCheck> _dailyCheckRepository;
        private readonly IRepository<DailyCheckPackagesValues> _dailyCheckPackagesValuesRepository;
        private readonly IRepository<DailyCheckDetail> _dailyCheckDetailRepository;
        private readonly IRepository<PaymentProcess> _paymentProcessRepository;
        private readonly IRepository<Campaign> _campaignRepository;
        private readonly IRepository<UsedCampaign> _usedCampaignRepository;

        public PackageService(IRepository<Package> repository, IUserService userRepository
            , IRepository<DailyCheck> dailyCheckRepository
            , IRepository<DailyCheckPackagesValues> dailyCheckPackagesValuesRepository
            , IRepository<DailyCheckDetail> dailyCheckDetailRepository
            , IRepository<PaymentProcess> paymentProcessRepository
            , IRepository<Campaign> campaignRepository
            , IRepository<UsedCampaign> usedCampaignRepository) : base(repository)
        {
            _userRepository = userRepository;
            _dailyCheckRepository = dailyCheckRepository;
            _dailyCheckPackagesValuesRepository = dailyCheckPackagesValuesRepository;
            _dailyCheckDetailRepository = dailyCheckDetailRepository;
            _paymentProcessRepository = paymentProcessRepository;
            _campaignRepository = campaignRepository;
            _usedCampaignRepository = usedCampaignRepository;
        }
        public IEnumerable<Package> GetPackages(bool onlyFree)
        {
            Expression<Func<Package, bool>> Filter = (p => p.IsActive && !p.IsDeleted);
            if (onlyFree)
                Filter = Filter.AndAlso(p => p.Offers.Any(x => x.IsActive && !x.IsDeleted && x.IsFree));
            var result = _repository.Where(Filter)
                .Include(p => p.Offers)
                .Include(p => p.RelPackageDetail)
                .ThenInclude(p => p.PackageDetail)
                .ToList();
            result = result.Select(p =>
            {
                p.Offers = p.Offers.Where(x => x.IsActive && !x.IsDeleted).ToList();
                p.RelPackageDetail = p.RelPackageDetail.Where(x => x.IsActive && !x.IsDeleted && x.PackageDetail.IsActive && !x.PackageDetail.IsDeleted).ToList();
                return p;
            }).ToList();
            return result;
        }
        public PackageBuyResult BuyPackage(int userId, int packageId, int offerId, int doctorId)
        {
            var result = new PackageBuyResult();
            result.Status = BuyStatus.Error;
            result.Description = "İşlem Sırasında Bir Hata Oluştu!";
            var user = _userRepository.GetItem(userId, "Address");
            if (user.IsActive)
            {
                var package = _repository.Where(p => p.Id == packageId).Include(p => p.Offers).FirstOrDefault();
                if (package != null)
                {
                    var offer = package.Offers.FirstOrDefault(p => p.Id == offerId);
                    if (offer.IsFree)
                    {
                        if (package.IsDoctor || package.IsDoctorSpec)
                        {
                            if (_dailyCheckRepository.CountByWhere(p => p.PackageId == packageId && p.NurseId == doctorId && p.UserId == user.Id) > 0)
                                result.Description = "Bu pakete zaten sahipsiniz!";
                            else
                            {
                                if (SetFreePackage(package, offer, user.Id, doctorId))
                                {
                                    result.Status = BuyStatus.Success;
                                    result.Description = $"{package.PackegeName} hesabınıza tanımlanmıştır.";
                                }
                            }
                        }
                        else
                        {
                            if (_dailyCheckRepository.CountByWhere(p => p.PackageId == packageId && p.UserId == user.Id) > 0)
                                result.Description = "Bu pakete zaten sahipsiniz!";
                            else
                            {
                                if (SetFreePackage(package, offer, user.Id, 1))
                                {
                                    result.Status = BuyStatus.Success;
                                    result.Description = $"{package.PackegeName} hesabınıza tanımlanmıştır.";
                                }
                            }
                        }
                    }
                    else
                    {
                        var amount = (double)offer.NewAmount;
                        if (user.AccountBalance > 0)
                        {
                            if ((decimal)amount > user.AccountBalance)
                            {
                                amount -= (double)user.AccountBalance;
                            }
                            else
                            {
                                user.AccountBalance -= (decimal)amount;
                                createPackage(user.Id, package, (decimal)amount, offer.ValidityDates, doctorId, $"BalanceCheckPackagev{package.Id}");
                                _paymentProcessRepository.Add(new PaymentProcess()
                                {
                                    IDate = DateTime.Now,
                                    userId = userId,
                                    ProcessMessage = "Takip Paketi Kayıt Başarılı || Paket Adı:" + package.PackegeName + " Kişi:" + user.Name + " " + user.SurName + " Başlangıç Tarihi:" + DateTime.Now + " - " + offer.ValidityDates + "  Ücret:" + 0 + " Kredi:" + amount,
                                    ServiceId = package.Id
                                });
                                result.Status = BuyStatus.Success;
                                result.Description = $"{package.PackegeName} hesabınıza tanımlanmıştır.";
                            }
                        }
                        result.User = user;
                        result.Package = package;
                        result.DoctorId = doctorId;
                        result.Amount = amount;
                        result.ValidityDates = offer.ValidityDates;
                        result.Status = BuyStatus.PaymentRedirect;
                    }
                }
                else
                    result.Description = "Bu paket Satışa Kapalıdır!";
            }
            else
                result.Description = "Hesabınız onaylı değil! Lütfen hesabınızı onaylayın!";
            return result;
        }
        public (bool, string) ValidateCampaignCode(int userId, string code)
        {
            var result = (false, "İşlem Sırasında Hata Oluştu!");
            try
            {
                //var isused = !_campaignRepository.Where(p => p.IsActive && !p.IsDeleted && p.Code == code && !p.UsedCampaigns.Any(x => x.UserId == userId && x.IsActive && !x.IsDeleted) && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Credit).Include(p => p.UsedCampaigns).Any();
                var _campaigns = _campaignRepository.Where(p => p.IsActive && !p.IsDeleted && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Credit).Include(p => p.UsedCampaigns).ToList();
                var isused = !_campaigns.Where(p => p.Code.ToUpperInvariant() == code.ToUpperInvariant() && !p.UsedCampaigns.Any(x => x.UserId == userId && x.IsActive && !x.IsDeleted)).Any();
                if (isused)
                    result.Item2 = "Kampanya kodu bulunamadı yada daha önce kullanılmıştır!";
                else
                {
                    var user = _userRepository.GetItem(userId);
                    var campaigne = _campaignRepository.Where(p => p.IsActive && !p.IsDeleted && p.Code == code && (p.StartDate <= DateTime.Now && p.EndDate >= DateTime.Now) && p.CampaignType == CampaignType.Credit).FirstOrDefault();
                    if (campaigne != null)
                    {
                        user.AccountBalance += campaigne.Value;
                        if (_userRepository.Save(user))
                        {
                            var used = new UsedCampaign
                            {
                                CampaignId = campaigne.Id,
                                UserId = user.Id,
                                UsedAmount = campaigne.Value
                            };
                            if (_usedCampaignRepository.Add(used))
                                result.Item1 = true;
                            else
                            {
                                user.AccountBalance -= campaigne.Value;
                                user.UsedCampaigns = null;
                                _userRepository.Save(user);
                                result.Item2 = "Kampanya tanımlanırken bir hata oluştu!";
                            }
                        }
                        else
                            result.Item2 = "Kampanya tanımlanırken bir hata oluştu!";
                    }
                    else
                        result.Item2 = "Kampanya kodunun geçerlilik süresi bitmiştir!";
                }
            }
            catch (Exception)
            {
            }
            return result;
        }
        private bool SetFreePackage(Package package, PackageOffers offer, int userId, int doctorId)
        {
            var result = false;
            try
            {
                DailyCheck newdailypackage = new DailyCheck()
                {
                    PaymentId = $"FreeDailyCheckPackagev{package.Id}",
                    UserId = userId,
                    IsPremium = true,
                    PackageName = package.PackegeName,
                    AlertDay = DateTime.Now,
                    Finish = DateTime.Now.AddDays(offer.ValidityDates),
                    PaymentPrice = 0,
                    Status = 0,
                    Start = DateTime.Now,
                    AlertDayCounter = 1,
                    NurseAlertDays = "0",
                    NurseId = doctorId,
                    IsDeleted = false,
                    IsDoctor = doctorId > 0,
                    PackageId=package.Id
                };
                result = _dailyCheckRepository.Add(newdailypackage);
                if (result)
                    foreach (var item in _dailyCheckPackagesValuesRepository.Where(x => x.IsDefault).ToList())
                    {
                        _dailyCheckDetailRepository.Add(
                         new DailyCheckDetail()
                         {
                             DailyCheckId = newdailypackage.Id,
                             TitleOrder = item.TitleOrder,
                             ValuesTitleId = item.Id
                         }
                         );
                    }
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private void createPackage(int userId, Package package, decimal price, int day, int doctorId, string paymentId)
        {
            DailyCheck dailyCheckKontrol = _dailyCheckRepository.FirstOrDefault(x => x.PackageId == package.Id && x.UserId == userId);
            if (dailyCheckKontrol != null)
            {
                if (dailyCheckKontrol.Finish > DateTime.Now)
                {
                    dailyCheckKontrol.Finish = dailyCheckKontrol.Finish.AddDays(day);
                }
                else
                {
                    dailyCheckKontrol.Start = DateTime.Now;
                    dailyCheckKontrol.Finish = DateTime.Now.AddDays(day);
                }
            }
            else
            {
                DailyCheck newdailypackage = new DailyCheck()
                {
                    PaymentId = paymentId,
                    UserId = userId,
                    IsPremium = package.IsPremium,
                    PackageName = package.PackegeName,
                    AlertDay = DateTime.Now,
                    Finish = DateTime.Now.AddDays(day),
                    PaymentPrice = price,
                    Status = Convert.ToInt16(package.IsPremium == true ? -1 : 0),
                    Start = DateTime.Now,
                    AlertDayCounter = 1,
                    NurseAlertDays = "0",
                    NurseId = 1,
                    IsDeleted = false,
                    PackageId = package.Id
                };
                if (doctorId > 0)
                {
                    newdailypackage.IsDoctor = true;
                    newdailypackage.NurseId = doctorId;
                }
                _dailyCheckRepository.Add(newdailypackage);
                if (!package.IsPremium)
                {
                    int ordercounter = 0;
                    var packageValues = package.RelPackageValues
                        .Where(p => p.IsActive && !p.IsDeleted)
                        .Select(p => p.DailyCheckPackagesValues).ToList();

                    foreach (var item in packageValues)
                    {
                        _dailyCheckDetailRepository.Add(new DailyCheckDetail()
                        {
                            DailyCheckId = newdailypackage.Id,
                            TitleOrder = ++ordercounter,
                            ValuesTitleId = Convert.ToInt16(item)
                        });
                    }
                }
                foreach (var item in _dailyCheckPackagesValuesRepository.Where(x => x.IsDefault).ToList())
                {
                    _dailyCheckDetailRepository.Add(
                         new DailyCheckDetail()
                         {
                             DailyCheckId = newdailypackage.Id,
                             TitleOrder = item.TitleOrder,
                             ValuesTitleId = item.Id
                         }
                     );
                }
            }
        }
    }
}
