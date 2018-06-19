using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShopingOnline.Model.Models;

namespace TeduShopingOnline.Service.Interfaces
{
    public interface IOrderService
    {
        Order CreateOrder(Order order, List<OrderDetail> orderDetails);
    }
}
