using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignWebUI.APIs
{
    public interface IProductAPI
    {
        [Get("/api/product/getproductinfo")]
        Task<ApiResponse<string>> GetProductInfo(string ProductCode);

        [Get("/api/product/resetproducts")]
        Task<ApiResponse<bool>> ResetProducts();

        [Get("/api/product/createproduct")]
        Task<ApiResponse<string>> CreateProduct(string ProductCode,int Price,int Stock);
    }
}
