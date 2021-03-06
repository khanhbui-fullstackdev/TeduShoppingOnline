﻿using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Data.Repositories.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        IEnumerable<Brand> GetTopBrand();
    }
}
