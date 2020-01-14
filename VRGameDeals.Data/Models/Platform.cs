using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VRGameDeals.Data.Models
{
    public class Platform
    {
        [Key]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<PlatformGame> Games { get; set; }

        public Platform()
        {
            Games = new List<PlatformGame>();
        }
    }
}