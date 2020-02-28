using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampaignWebUI.APIs
{
    public interface ITimeAPI
    {
        [Get("/api/time/increasetime")]
        Task<ApiResponse<string>> IncreaseTime(int Amount);

        [Get("/api/time/resettime")]
        Task<ApiResponse<bool>> ResetTime();
    }
}
