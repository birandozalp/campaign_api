using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
    public interface IOrderRepository
    {
        public OrderEntity CreateOrder(string ProductCode, int Quantity);

        public bool ResetOrders();
    }
}
