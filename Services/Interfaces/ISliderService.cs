using Data.Domain;
using Domain.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ISliderService : IService<Slider>
    {
        public IEnumerable<Slider> GetMobileSliders();

    }
}
