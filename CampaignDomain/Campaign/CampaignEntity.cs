using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignDomain.Campaign
{
    public class CampaignEntity
    {
        public CampaignEntity()
        {

        }
        public CampaignEntity(string Name, string ProductCode, int Duration, int PriceManipulationLimit, int TargetSalesCount)
        {
            this.Duration = Duration;
            this.Name = Name;
            this.ProductCode = ProductCode;
            this.TargetSalesCount = TargetSalesCount;
            this.PriceManipulationLimit = PriceManipulationLimit;
        }

        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public int PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        public int TotalSales { 
            
            get {
                int totalSales = 0;

                foreach(var order in Order.OrderMemoryCache.CurrentOrders)
                {
                    if(order.Campaign == this.Name)
                    {
                        totalSales = totalSales + order.Quantity;
                    }
                }
                return totalSales;
            } }

        public int TurnOver
        {
            get{
                int turnOver = 0;


                foreach (var order in Order.OrderMemoryCache.CurrentOrders)
                {
                    if (order.Campaign == this.Name)
                    {
                        turnOver = turnOver + order.OrderPrice;
                    }
                }
                return turnOver;
            }
        }

        public bool isActive
        {
            get { return Duration >= Time.TimeMemoryCache.CurrentTime.Hour ? true : false; }
        }

    }
}
