using Data.Domain;
using Domain.Interfaces.Base;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface IPackageService : IService<Package>
    {
        IEnumerable<Package> GetPackages(bool onlyFree);
        PackageBuyResult BuyPackage(int userId, int packageId, int offerId, int doctorId);
        (bool, string) ValidateCampaignCode(int userId, string code);
    }
}
