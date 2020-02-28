using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
    public class OrderRepository : IOrderRepository
    {
        public OrderEntity CreateOrder(string ProductCode, int Quantity)
        {
            OrderEntity newOrder = new OrderEntity(ProductCode, Quantity);
            OrderMemoryCache.CurrentOrders.Add(newOrder);
            return newOrder;
        }

        public bool ResetOrders()
        {
            OrderMemoryCache.CurrentOrders = new List<OrderEntity>();
            return true;
        }
    }
}
