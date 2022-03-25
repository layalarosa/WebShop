using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _appDbContext;

        public GameRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Game> AllGames
        {
            get
            {
                return _appDbContext.Games.Include(c => c.Category);
            }
        }

        public IEnumerable<Game> GamesOfTheWeek
        {
            get
            {
                return _appDbContext.Games.Include(c => c.Category).Where(p => p.IsGameOfTheWeek);
            }
        }

        public Game GetGameById(int gameId)
        {
            return _appDbContext.Games.FirstOrDefault(p => p.GameId == gameId);
        }
    }
}
