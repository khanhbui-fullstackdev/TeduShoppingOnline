using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service
{
    public interface ICommonService
    {
        Footer GetFooterById(string footerId);
        
    }
}
