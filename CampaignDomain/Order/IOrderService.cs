using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
    public interface IOrderService
    {
        OrderEntity CreateOrder(string ProductCode, int Quantity);
        bool ResetOrders();
    }
}
