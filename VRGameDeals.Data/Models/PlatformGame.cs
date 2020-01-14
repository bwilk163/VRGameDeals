using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VRGameDeals.Data.Models
{
    public class PlatformGame
    {
        
        [Key]
        public Guid Guid{ get; set; }
        public Guid GameGuid { get; set; }
        public Game Game { get; set; }
        public Guid PlatformGuid { get; set; }
        public Platform Platform { get; set; }

        public PlatformGame(Guid gameGuid, Guid platformGuid)
        {
            Guid = Guid.NewGuid();
            GameGuid = gameGuid;
            PlatformGuid = platformGuid;
        }
    }
}
