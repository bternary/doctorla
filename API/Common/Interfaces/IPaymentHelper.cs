using Domain.Models;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Common.Interfaces
{
    public interface IPaymentHelper
    {
        BuyResult BuyPackage(PackageBuyResult data, string ip);
        BuyResult BuyAppointment(AppointmentBuyResult data, string ip);
    }
}
