using Data.Domain;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces.Repositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        void FillTurkeyCountryData();
    }
}
