using Data.Domain;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Interfaces.Repositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Data.Interfaces;
using Domain.Interfaces.Base;

namespace Services
{
    public class RegionService : Service<Country>, IRegionService
    {
        private readonly IRepository<City> cityRepo;
        private readonly IRepository<County> countyRepo;
        public RegionService(ICountryRepository countryRepository, IRepository<City> cityRepo, IRepository<County> countyRepo) : base(countryRepository)
        {
            this.cityRepo = cityRepo;
            this.countyRepo = countyRepo;

        }
        public List<City> GetCities(int countryId)
        {
            return cityRepo.Where(p => p.IsActive && !p.IsDeleted && p.CountryId == countryId).ToList();
        }

        public List<County> GetCounties(int cityId)
        {
            return countyRepo.Where(p => p.IsActive && !p.IsDeleted && p.CityId == cityId).ToList();
        }
    }
}
