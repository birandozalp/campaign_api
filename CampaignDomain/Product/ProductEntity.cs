using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Product

{
    public class ProductEntity
    {
        public  ProductEntity(string productCode,int price,int stock)
        {
            this.ProductCode = productCode;
            this.Price = price;
            this.Stock = stock;
            this.OriginalPrice = price;
        }
        public string ProductCode { get; set; }
        public int Price { get; set; }

        public int OriginalPrice { get; set; }
        public int Stock { get; set; }
    }
}
