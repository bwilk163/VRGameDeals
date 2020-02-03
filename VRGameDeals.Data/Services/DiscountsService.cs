using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRGameDeals.Data.EF;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.Services
{
    public class DiscountsService : IDiscountsService
    {
        private readonly DatabaseContext _databaseContext;
        public DiscountsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            var result = await _databaseContext.Discounts.ToListAsync();
            return result;
        }
    }
}