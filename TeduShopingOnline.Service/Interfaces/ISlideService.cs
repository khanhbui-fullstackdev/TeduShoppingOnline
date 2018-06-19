using System.Collections.Generic;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service
{
    public interface ISlideService
    {
        IEnumerable<Slide> GetAllSlides();
    }
}
