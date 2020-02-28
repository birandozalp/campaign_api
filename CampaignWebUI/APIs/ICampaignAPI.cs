using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignWebUI.APIs
{
    public interface ICampaignAPI
    {
        [Get("/api/campaign/getcampaigninfo")]
        Task<ApiResponse<string>> GetCampaignInfo(string Name);

        [Get("/api/campaign/resetcampaign")]
        Task<ApiResponse<bool>> ResetCampaign();

        [Get("/api/campaign/createcampaign")]
        Task<ApiResponse<string>> CreateCampaign(string Name, string ProductCode, int Duration, int PriceManipulationLimit, int TargetSalesCount);
    }
}
