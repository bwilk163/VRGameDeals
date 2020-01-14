using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRGameDeals.Data.EF;
using VRGameDeals.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace VRGameDeals.Data.Services
{
    public class PlatformsService
    {
        private readonly DatabaseContext _databaseContext;
        public PlatformsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Platform>> GetAll()
        {
            var platforms = await _databaseContext.Platforms.ToListAsync();
            return platforms;
        }

        public async Task<Platform> Add(Platform platform)
        {
            var platformEntity = _databaseContext.Platforms.Add(platform);
            await _databaseContext.SaveChangesAsync();
            return platformEntity.Entity;
        }

        public async Task<Platform> Update(Guid guid, Platform platform)
        {
            var platformEntity = await _databaseContext.Platforms.FirstOrDefaultAsync(x => x.Guid == guid);
            platformEntity.Name = platform.Name;
            platformEntity.Description = platform.Description;

            _databaseContext.Update(platformEntity);
            await _databaseContext.SaveChangesAsync();

            return platformEntity;
        }


        //public async Task<Game> GetGamesForPlatform(Guid platformGuid)
        //{
        //    var games = await _databaseContext.Games.Where(x=>x.Platforms.Contains(platformGuid))
        //}
    }
}
