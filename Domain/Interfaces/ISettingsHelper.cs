using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ISettingsHelper
    {
        public string GetSetting(string key);
    }
}
