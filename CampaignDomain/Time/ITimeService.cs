using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Time
{
    public interface ITimeService
    {

        TimeEntity IncreaseTime(int Amount);
        bool ResetTime();

    }
}
