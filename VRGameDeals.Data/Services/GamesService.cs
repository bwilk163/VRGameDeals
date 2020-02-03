using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using VRGameDeals.Data.EF;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.Services
{
    public class GamesService : IGamesService 
    {
        private readonly DatabaseContext _databaseContext;
        public GamesService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Game>> GetAll()
        {
            var games = await _databaseContext.Games.Include(g => g.Platforms).ThenInclude(p => p.Platform).ToListAsync();
            return games;
        }

        public async Task<Game> Add(Game game)
        {
            var g = _databaseContext.Games.Add(game);
            await _databaseContext.SaveChangesAsync();
            return g.Entity;
        }

        public async Task<Game> Update(Guid guid, Game game)
        {
            var g = await _databaseContext.Games.FirstOrDefaultAsync(x => x.Guid == guid);
            g.Description = game.Description;
            g.Name = game.Name;
            g.Platforms = game.Platforms;

            _databaseContext.Update(g);

            await _databaseContext.SaveChangesAsync();
            return g;
        }

        public async Task<Game> AddPlatformToGame(Guid gameId, Guid platformId, DateTime releaseDate, decimal price)
        {
            var game = await _databaseContext.Games.Include(p => p.Platforms).FirstOrDefaultAsync(x => x.Guid == gameId);
            var platform = await _databaseContext.Platforms.FirstOrDefaultAsync(x => x.Guid == platformId);
            game.Platforms.Add(new PlatformGame(game.Guid, platform.Guid, releaseDate, price ));

            _databaseContext.Update(game);
            await _databaseContext.SaveChangesAsync();

            return game;
        }
    }
}