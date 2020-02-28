using CampaignDomain.Time;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public class CampaignService:ICampaignService
    {
        private ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public CampaignEntity CreateCampaign(string Name,string ProductCode, int Duration,int PriceManipulationLimit,int TargetSalesCount)
        {
            var result = _campaignRepository.CreateCampaign(Name, ProductCode, Duration, PriceManipulationLimit, TargetSalesCount);
            return result;
        }

        public CampaignEntity GetCampaignInfo(string Name)
        {
            var result = _campaignRepository.GetCampaignInfo(Name);
            return result;
        }

        public bool ResetCampaign()
        {
            var result = _campaignRepository.ResetCampaign();
            return result;
        }
    }
}
