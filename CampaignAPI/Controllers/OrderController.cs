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
    public class OrderController : ControllerBase
    {

        private IOrderService _orderService;
        private ICampaignService _campaignService;
        private IProductService _productService;
        private ITimeService _timeService;

        public OrderController(IOrderService orderService, ICampaignService campaignService, IProductService productService, ITimeService timeService)
        {
            _orderService = orderService;
            _campaignService = campaignService;
            _productService = productService;
            _timeService = timeService;
        }

        [HttpGet]
        public ActionResult<string> Order()
        {
            return "No command initiated.";
        }

        [HttpGet("CreateOrder")]
        public ActionResult<string> CreateOrder(string productCode, int Quantity)
        {
            var result = _orderService.CreateOrder(productCode, Quantity);
            return "Order created; product " + result.ProductCode + ", quantity  " + result.Quantity;
        }

        [HttpGet("ResetOrders")]
        public ActionResult<bool> ResetOrders()
        {
            var result = _orderService.ResetOrders();
            return result;
        }
    }
}