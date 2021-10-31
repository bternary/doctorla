using Data.Domain;
using Domain.Interfaces.Base;
using Domain.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IDailyCheckService : IService<DailyCheckAlerts>
    {
        GenericServiceListModel<DailyCheckAlerts> GetAlerts(int userId, int daylycheckId, SortingPagingInfo sorting);
        bool Save(DailyCheckAlerts alert);
        bool Delete(int dailycheckAlertId);
        (bool, string) CreateDailyCheckDetail(int userId, int dailyCheckId, List<DailyCheckValues> values, List<FileReqModel> files);
        List<DailyCheckDetail> GetDailyCheckDetails(int userId, int dailyCheckId, string filter = "");
        List<PackageChat> GetChatList(int dailyCheckId);
        bool SendChat(int dailyCheckId, string message, FileReqModel file, bool isDoctor);
        GenericServiceListModel<DailyCheck> GetUserDailyChecks(int userId, SortingPagingInfo sorting);
    }
}
