using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignWebUI.APIs
{
    public interface IOrderAPI
    {
        [Get("/api/order/createorder")]
        Task<ApiResponse<string>> CreateOrder(string ProductCode, int Quantity);

        [Get("/api/order/resetorders")]
        Task<ApiResponse<bool>> ResetOrders();
    }
}
