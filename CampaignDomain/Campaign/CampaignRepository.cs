using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public class CampaignRepository : ICampaignRepository
    {
        public CampaignRepository()
        {
            
        }

        public bool ResetCampaign()
        {
            CampaignMemoryCache.CurrentCampaign = new CampaignEntity();
            return true;
        }
        public CampaignEntity GetCampaignInfo(string campaignCode)
        {

                if(CampaignMemoryCache.CurrentCampaign.Name == campaignCode)
                {
                    return CampaignMemoryCache.CurrentCampaign;
                }

            return null;
        }

        public CampaignEntity CreateCampaign(string Name, string ProductCode, int Duration, int PriceManipulationLimit, int TargetSalesCount)
        {
            CampaignEntity newCampaign = new CampaignEntity(Name,ProductCode,Duration,PriceManipulationLimit,TargetSalesCount);
            CampaignMemoryCache.CurrentCampaign = newCampaign;
            return newCampaign;
        }

        public CampaignEntity GetActiveCampaign()
        {
            {
                if (CampaignMemoryCache.CurrentCampaign.isActive == true)
                {
                    return CampaignMemoryCache.CurrentCampaign;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
