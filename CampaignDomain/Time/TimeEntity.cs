using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Time
{
    public class TimeEntity
    {
        public TimeEntity()
        {
            this.Hour = 0;
        }

        public int Hour { get; set; }
    }
}
