using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignDomain.Campaign;
using CampaignDomain.Order;
using CampaignDomain.Product;
using CampaignDomain.Time;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CampaignAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private IOrderService _orderService;
        private ICampaignService _campaignService;
        private IProductService _productService;
        private ITimeService _timeService;

        public CampaignController(IOrderService orderService, ICampaignService campaignService, IProductService productService, ITimeService timeService)
        {
            _orderService = orderService;
            _campaignService = campaignService;
            _productService = productService;
            _timeService = timeService;
        }

        [HttpGet]
        public ActionResult<string> Campaign()
        {
            return "No command initiated.";
        }

        [HttpGet("CreateCampaign")]
        public ActionResult<string> CreateCampaign(string name, string productCode, int duration, int priceManipulationLimit, int targetSalesCount)
        {
            var result = _campaignService.CreateCampaign(name, productCode, duration, priceManipulationLimit, targetSalesCount);
            return "Campaign created; name " + result.Name + ", product " + result.ProductCode + ", duration " + result.Duration + ", limit " + result.PriceManipulationLimit + ", target sales count " + result.TargetSalesCount;
        }

        [HttpGet("GetCampaignInfo")]
        public ActionResult<string> GetCampaignInfo(string name)
        {
            var result = _campaignService.GetCampaignInfo(name);



            if (result != null)
            {
                string averagePrice;
                if(result.TurnOver>0 && result.TotalSales>0)
                {
                    averagePrice = (result.TurnOver / result.TotalSales).ToString();
                }
                else
                {
                    averagePrice = "-";
                }

                string Status = result.isActive ? "Active" : "Ended";

                string response = "Campaign " + result.Name  + " info; " +  " Status " + Status + ", Target Sales "+ result.TargetSalesCount +", TotalSales " + result.TotalSales + ", Turnover " + result.TurnOver + ", Avarage Item Price " + averagePrice;
                return response;
            }
            else
            {
                return "Couldn't Find";
            }

        }

        [HttpGet("ResetCampaign")]
        public ActionResult<bool> ResetCampaign()
        {
            var result = _campaignService.ResetCampaign();
            return result;
        }

    }
}
