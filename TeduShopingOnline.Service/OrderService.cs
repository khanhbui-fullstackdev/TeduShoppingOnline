using System;
using System.Collections.Generic;
using TeduShopingOnline.Data.Infrastructures;
using TeduShopingOnline.Data.Repositories.Interfaces;
using TeduShopingOnline.Model.Models;
using TeduShopingOnline.Service.Interfaces;

namespace TeduShopingOnline.Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IOrderDetailRepository _orderDetailRepository;
        IUnitOfWork _unitOfWork;

        public OrderService(
            IOrderRepository orderRepository,
            IOrderDetailRepository orderDetailRepository,
            IUnitOfWork unitOfWork)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._orderRepository = orderRepository;
            this._unitOfWork = unitOfWork;
        }

        public Order CreateOrder(Order order, List<OrderDetail> orderDetails)
        {
            try
            {
                var newOrder = _orderRepository.Add(order);
                _unitOfWork.Commit();

                foreach (var orderDetail in orderDetails)
                {
                    orderDetail.OrderID = newOrder.ID;
                    _orderDetailRepository.Add(orderDetail);
                }
                _unitOfWork.Commit();
                return newOrder;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
