using Data.Domain;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IRegionService: IService<Country>
    {
        List<County> GetCounties(int countryId);
        List<City> GetCities(int CountiyId);
    }
}
