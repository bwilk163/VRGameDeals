using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VRGameDeals.Api.Commands
{

    public class PlatformGameCommand
    {
        public Guid PlatformId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
    }
}
