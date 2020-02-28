using CampaignDomain.Campaign;
using CampaignDomain.Product;
using CampaignDomain.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Order
{
    public class OrderService :IOrderService
    {
        private IOrderRepository _orderRepository;
        private ICampaignRepository _campaignRepository;
        private IProductRepository _productRepository;
        private ITimeRepository _timeRepository;

        public OrderService(IOrderRepository orderRepository,ICampaignRepository campaignRepository,IProductRepository productRepository,ITimeRepository timeRepository)
        {
            _orderRepository = orderRepository;
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
            _timeRepository = timeRepository;
        }
        public OrderEntity CreateOrder(string ProductCode,int Quantity)
        {
            var result = _orderRepository.CreateOrder(ProductCode, Quantity);
            var currentCampaign = _campaignRepository.GetActiveCampaign();
            var productOrdered = _productRepository.GetProductInfo(ProductCode);
            productOrdered.Stock = productOrdered.Stock - Quantity;

            if(currentCampaign != null && currentCampaign.ProductCode == productOrdered.ProductCode)
            {
                result.Campaign = currentCampaign.Name;
            }
            
            return result;
        }

        public bool ResetOrders()
        {
            return _orderRepository.ResetOrders();
        }
    }
}
