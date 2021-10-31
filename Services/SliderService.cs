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
    public class SliderService : Service<Slider>, ISliderService
    {
        public SliderService(IRepository<Slider> sliderRepostory) : base(sliderRepostory)
        {
        }

        public IEnumerable<Slider> GetMobileSliders()
        {
            return _repository.Where(p => p.IsActive && !p.IsDeleted && p.IsMobile).ToList();
        }
    }
}
