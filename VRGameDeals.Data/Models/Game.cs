using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VRGameDeals.Data.Models
{
    public class Game
    {
        [Key]
        public Guid Guid { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlatformGame> Platforms { get; set; }

        public Game()
        {
            Platforms = new List<PlatformGame>();
        }
    }
}