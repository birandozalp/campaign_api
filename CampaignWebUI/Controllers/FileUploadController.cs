using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampaignWebUI.APIs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CampaignWebUI.Controllers
{
    public class FileUploadController : Controller

    {
        private readonly IProductAPI _productAPI;
        private readonly IOrderAPI _orderAPI;
        private readonly ITimeAPI _timeAPI;
        private readonly ICampaignAPI _campaignAPI;

        public FileUploadController(IProductAPI productAPI,IOrderAPI orderAPI,ITimeAPI timeAPI,ICampaignAPI campaignAPI)
        {
            _productAPI = productAPI;
            _orderAPI = orderAPI;
            _timeAPI = timeAPI;
            _campaignAPI = campaignAPI;
        }
        public IActionResult Index(IFormFile file)

        {

            return View();

        }



        [HttpGet]

        public IActionResult UploadFile(IFormFile file)

        {





            return View();

        }





        [HttpPost]

        public List<string> UploadFile()

        {

            var files = Request.Form.Files;

            var textFile = files.FirstOrDefault();

            var listOfCommands = new List<string>();

            var ListOfResults = new List<string>();

            using (var reader = new StreamReader(textFile.OpenReadStream()))

            {

                while (reader.Peek() >= 0)

                {

                    listOfCommands.Add(reader.ReadLine());

                }

            }


            foreach (var line in listOfCommands)
            {
                string result = null;
                string[] commandAndParameters = line.Split(" ");
                
                switch(commandAndParameters[0])
                {
                    case "create_product":
                        result = _productAPI.CreateProduct(commandAndParameters[1],Convert.ToInt32(commandAndParameters[2]), Convert.ToInt32(commandAndParameters[3])).Result.Content;
                        break;

                    case "get_product_info":

                        result = _productAPI.GetProductInfo(commandAndParameters[1]).Result.Content;
                        break;

                    case "create_order":
                        result = _orderAPI.CreateOrder(commandAndParameters[1], Convert.ToInt32(commandAndParameters[2])).Result.Content;
                        break;

                    case "create_campaign":
                        result = _campaignAPI.CreateCampaign(commandAndParameters[1], commandAndParameters[2], Convert.ToInt32(commandAndParameters[3]), Convert.ToInt32(commandAndParameters[4]), Convert.ToInt32(commandAndParameters[5])).Result.Content;
                        break;

                    case "get_campaign_info":
                        result = _campaignAPI.GetCampaignInfo(commandAndParameters[1]).Result.Content;
                        break;

                    case "increase_time":
                        result = _timeAPI.IncreaseTime(Convert.ToInt32(commandAndParameters[1])).Result.Content;
                        break;
                }

                ListOfResults.Add(result);

            }

            _timeAPI.ResetTime();
            _campaignAPI.ResetCampaign();
            _orderAPI.ResetOrders();
            _productAPI.ResetProducts();

            return ListOfResults;
           

        }



    }
}