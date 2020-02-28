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
    public class ProductController : ControllerBase
    {
        private IOrderService _orderService;
        private ICampaignService _campaignService;
        private IProductService _productService;
        private ITimeService _timeService;

        public ProductController(IOrderService orderService, ICampaignService campaignService, IProductService productService, ITimeService timeService)
        {
            _orderService = orderService;
            _campaignService = campaignService;
            _productService = productService;
            _timeService = timeService;
        }

        [HttpGet]
        public ActionResult<string> Product()
        {
            return "No command initiated.";
        }

        [HttpGet("CreateProduct")]
        public ActionResult<string> CrateProduct(string ProductCode, int Price, int Stock)
        {
            var result = _productService.CreateProduct(ProductCode, Price, Stock);
            return "Product created; code " + result.ProductCode + ", price " + result.Price + ", stock " + result.Stock;
        }

        [HttpGet("ResetProducts")]
        public ActionResult<bool> ResetProducts()
        {
            return _productService.ResetProducts();
        }

        [HttpGet("GetProductInfo")]
        public ActionResult<string> GetProductInfo(string productCode)
        {
            var result = _productService.GetProductInfo(productCode);



            if (result != null)
            {
                return "Product " +result.ProductCode+" info; price " + result.Price + ", stock " + result.Stock;
            }
            else
            {
                return "Couldn't Find";
            }
        }
    }
}