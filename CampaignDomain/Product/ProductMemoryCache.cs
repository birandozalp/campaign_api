using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Product
{
    public static class ProductMemoryCache
    {
        public static List<ProductEntity> CurrentProducts = new List<ProductEntity>();
    }
}
