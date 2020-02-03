using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VRGameDeals.Data.Models;

namespace VRGameDeals.Data.Services
{
    public interface IGamesService
    {
        Task<IEnumerable<Game>> GetAll();

        Task<Game> Add(Game game);

        Task<Game> Update(Guid guid, Game game);

        Task<Game> AddPlatformToGame(Guid gameId, Guid platformId, DateTime releaseDate, decimal price);
    }
}