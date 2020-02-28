using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Product
{
    public interface IProductService
    {
        public ProductEntity CreateProduct(string ProductCode, int Price, int Stock);
        public ProductEntity GetProductInfo(string ProductCode);

        public bool ResetProducts();
    }
}
