using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
    public class OrderEntity
    {
        public OrderEntity(string productCode,int quantity)
        {
            this.ProductCode = productCode;
            this.Quantity = quantity;
             this.OrderPrice = (Product.ProductMemoryCache.CurrentProducts.Find(x => x.ProductCode == productCode).Price) * Quantity;
        }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public string Campaign { get; set; }

        public int OrderPrice { get; set; }
    }
}
