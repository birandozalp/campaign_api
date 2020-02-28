using CampaignDomain.Campaign;
using CampaignDomain.Order;
using CampaignDomain.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Time
{
    public class TimeService : ITimeService
    {
        private IOrderRepository _orderRepository;
        private ICampaignRepository _campaignRepository;
        private IProductRepository _productRepository;
        private ITimeRepository _timeRepository;
        public TimeService(IOrderRepository orderRepository, ICampaignRepository campaignRepository, IProductRepository productRepository, ITimeRepository timeRepository)
        {
            _orderRepository = orderRepository;
            _campaignRepository = campaignRepository;
            _productRepository = productRepository;
            _timeRepository = timeRepository;
        }

        public bool ResetTime()
        {
            _timeRepository.ResetTime();
            return true;
        }

        public TimeEntity IncreaseTime(int Amount)
        {
            var result = _timeRepository.IncreaseTime(Amount);


            var currentCampaign = _campaignRepository.GetActiveCampaign();
            if(currentCampaign != null)
            { 
                var productOfCurrentCampaign = _productRepository.GetProductInfo(currentCampaign.ProductCode);

                    int salesNeeded = currentCampaign.TargetSalesCount - currentCampaign.TotalSales;
                    int timeLeft = currentCampaign.Duration - TimeMemoryCache.CurrentTime.Hour;

                    int salesNeededPercentage = (int)((double)salesNeeded / currentCampaign.TargetSalesCount * 100);

                    int discountPercentage = salesNeededPercentage / timeLeft;

                    if (discountPercentage <= currentCampaign.PriceManipulationLimit)
                    {
                        int discountAmount = (int)((double)productOfCurrentCampaign.OriginalPrice / 100 * discountPercentage);
                        productOfCurrentCampaign.Price = productOfCurrentCampaign.OriginalPrice - discountAmount;
                    }
                    else
                    {
                    productOfCurrentCampaign.Price = productOfCurrentCampaign.OriginalPrice - ((int)((double)productOfCurrentCampaign.OriginalPrice / 100 * currentCampaign.PriceManipulationLimit));
                    }
                

            }

            else
            {
                foreach(var product in Product.ProductMemoryCache.CurrentProducts)
                {
                    product.Price = product.OriginalPrice;
                }
            }


            return result;
        }
    }
}
