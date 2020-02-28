using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Time
{
    public class TimeRepository : ITimeRepository
    {

        public TimeEntity IncreaseTime(int Amount)
        {
            TimeMemoryCache.CurrentTime.Hour = TimeMemoryCache.CurrentTime.Hour + Amount;
            return TimeMemoryCache.CurrentTime;
        }

        public bool ResetTime()
        {
            TimeMemoryCache.CurrentTime.Hour = 0;
            return true;
        }
    }
}
