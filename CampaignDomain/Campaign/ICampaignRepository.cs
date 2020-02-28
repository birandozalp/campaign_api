using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public interface ICampaignRepository
    {
        CampaignEntity GetCampaignInfo(string campaignCode);
        CampaignEntity CreateCampaign(string Name, string ProductCode, int Duration, int PriceManipulationLimit, int TargetSalesCount);
        CampaignEntity GetActiveCampaign();

        bool ResetCampaign();
       
    }
}
