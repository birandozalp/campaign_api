using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
        public static class OrderMemoryCache
        {
            public static List<OrderEntity> CurrentOrders = new List<OrderEntity>();
        }
    
}
