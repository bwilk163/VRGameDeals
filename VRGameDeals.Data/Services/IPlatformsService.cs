using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.Services
{
    public interface IPlatformsService
    {
        Task<IEnumerable<Platform>> GetAll();

        Task<Platform> Add(Platform platform);

        Task<Platform> Update(Guid guid, Platform platform);
    }
}