using Data.Domain;
using Domain.Interfaces.Base;
using Domain.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Services.Interfaces
{
    public interface IUserService : IService<User>
    {
        RefreshToken GenerateRefreshToken(int userId);
        bool ValidateRefreshToken(int userId, string refreshToken);
        (bool, int) ValidateUser(string username, string password);
        bool Save(User item);
        bool ValidateUserData(User user);
        int GenerateDoctorRandomCode();
        IEnumerable<Department> GetDepartments();
        (bool, string,string) GenerateActivationCode(int userId);
        bool ActivateUser(int userId, string activationCode);
        GenericServiceListModel<User> GetDoctorList(SortingPagingInfo sorting, int depatmentId, string doctorName);
        GenericServiceListModel<User> GetDoctors(SortingPagingInfo sorting, IEnumerable<int> doctorIds);
        bool ChangePassword(int userId, string oldPassword, string newPassword);
        bool UpdateUser(int userId, User updateuser, FileReqModel profilephoto);
        bool UpdateDocotorDepartmentPrice(int relUserDepartmentId, int price, int sessionTime);
        (bool, string, string, string) GenerateResetPasswordCode(string phone);
        (bool, string) ValidateResetPasswordCode(string phone, string code);
        (bool, string) ResetPassword(string code, string password);
        string GetAllUserSmsPush(int type, int year, int month, int day, string message);
    }
}
