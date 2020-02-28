using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Product
{
    public class ProductRepository:IProductRepository
    {
        public ProductEntity CreateProduct(string ProductCode,int Price,int Stock)
        {
            ProductEntity newProduct = new ProductEntity(ProductCode, Price, Stock);
            ProductMemoryCache.CurrentProducts.Add(newProduct);
            return newProduct;
        }
        public ProductEntity GetProductInfo(string ProductCode)
        {
            foreach(var product in ProductMemoryCache.CurrentProducts)
            {
                if(product.ProductCode == ProductCode)
                {
                    return product;
                }
            }

            return null;
        }

        public bool ResetProducts()
        {
            ProductMemoryCache.CurrentProducts = new List<ProductEntity>();
            return true;
        }
    }
}
