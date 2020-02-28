using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Time
{
    public interface ITimeRepository
    {
        TimeEntity IncreaseTime(int Amount);
        bool ResetTime();
    }
}
