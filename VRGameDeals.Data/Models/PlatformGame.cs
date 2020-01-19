using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VRGameDeals.Data.Models
{
    public class PlatformGame
    {
        public Guid GameId { get; set; }
        public virtual Game Game { get; set; }

        public Guid PlatformId { get; set; }
        public virtual Platform Platform { get; set; }

        /// <summary>
        /// Release date of a game on specific platform
        /// </summary>
        public DateTime ReleaseDate { get; set; }


        /// <summary>
        /// Price of a game on specific platform
        /// </summary>
        public decimal  Price { get; set; }

        protected PlatformGame()
        {

        }

        public PlatformGame(Guid gameGuid, Guid platformGuid, DateTime releaseDate, decimal price)
        {
            GameId = gameGuid;
            PlatformId = platformGuid;
            ReleaseDate = releaseDate;
            Price = price;
        }
    }
}
