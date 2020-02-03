using System;
using System.Collections.Generic;
using System.Text;

namespace VRGameDeals.Data.Models
{
    public class Discount
    {
        public Guid Guid { get; set; }

        /// <summary>
        /// Site where games is discounted
        /// </summary>
        public string Site { get; set; }
        public decimal Price { get; set; }

        /// <summary>
        /// When discount starts
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// When discount ends
        /// </summary>
        public DateTime EndDate { get; set; }

        public Guid PlatformGameId { get; set; }
        public virtual PlatformGame PlatformGame { get; set; }

        public Discount()
        {

        }

        public Discount(Guid guid, string site, decimal price, DateTime startDate, DateTime endDate, Guid platformGameId)
        {
            Guid = guid;
            Site = site;
            Price = price;
            StartDate = startDate;
            EndDate = endDate;
            PlatformGameId = platformGameId;
        }
    }
}