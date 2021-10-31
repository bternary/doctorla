using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Domain
{
    public class SettingsHelper : ISettingsHelper
    {
        private readonly IConfiguration _configuration = null;
        public SettingsHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetSetting(string key)
        {
            return _configuration[key];
        }
    }
}
