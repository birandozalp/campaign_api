using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public interface ICampaignService
    {
       public CampaignEntity CreateCampaign(string Name, string ProductCode, int Duration, int PriceManipulationLimit, int TargetSalesCount);
        public CampaignEntity GetCampaignInfo(string Name);

        public bool ResetCampaign();
    }
}
