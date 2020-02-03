using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.Services
{
    public interface IDiscountsService
    {
        Task<IEnumerable<Discount>> GetDiscounts();
    }
}