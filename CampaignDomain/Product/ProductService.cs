using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Product
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public ProductEntity CreateProduct(string ProductCode, int Price, int Stock)
        {
            var result = _productRepository.CreateProduct(ProductCode, Price, Stock);
            return result;
        }

        public ProductEntity GetProductInfo(string ProductCode)
        {
            var result = _productRepository.GetProductInfo(ProductCode);
            return result;
        }

        public bool ResetProducts()
        {
            return _productRepository.ResetProducts();
        }
    }
}
