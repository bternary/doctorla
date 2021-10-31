using Data;
using Data.Domain;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLibrary
{
    public static class LogsServices
    {
        public static void LogsAdd(string page, string path, string message, int type = 2)
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                DataContext dbcontext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                dbcontext.Logs.Add(new Logs() { IDate = DateTime.Now, UrlPath = path, Page = page, ErrorMessage = message, LogType = type });
                dbcontext.SaveChanges();
            }
        }
        public static void Log(string Page, string errormessage, int type)
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                DataContext dbcontext = serviceScope.ServiceProvider.GetRequiredService<DataContext>();
                dbcontext.Logs.Add(new Logs() { IDate = DateTime.Now, Page = Page, ErrorMessage = errormessage, LogType = type });
                dbcontext.SaveChanges();
            }
        }
    }
}
