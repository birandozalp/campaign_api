using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CampaignDomain.Campaign;
using CampaignDomain.Order;
using CampaignDomain.Product;
using CampaignDomain.Time;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampaignAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeController : ControllerBase
    {
        private IOrderService _orderService;
        private ICampaignService _campaignService;
        private IProductService _productService;
        private ITimeService _timeService;

        public TimeController(IOrderService orderService, ICampaignService campaignService, IProductService productService, ITimeService timeService)
        {
            _orderService = orderService;
            _campaignService = campaignService;
            _productService = productService;
            _timeService = timeService;
        }

        [HttpGet]
        public ActionResult<string> Time()
        {
            return "No command initiated.";
        }

        [HttpGet("IncreaseTime")]
        public ActionResult<string> IncreaseTime(int Amount)
        {
            var result = _timeService.IncreaseTime(Amount);
            return "Time is " + TimeMemoryCache.CurrentTime.Hour + ":00";
        }

        [HttpGet("ResetTime")]
        public ActionResult<bool> ResetTime()
        {
            return _timeService.ResetTime();
        }


    }
}