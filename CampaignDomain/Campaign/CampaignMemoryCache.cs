using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public static class CampaignMemoryCache
    {
        public static CampaignEntity CurrentCampaign = new CampaignEntity();
    }
}
