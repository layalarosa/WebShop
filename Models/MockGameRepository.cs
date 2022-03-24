using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class MockGameRepository : IGameRepository
    {
        private readonly ICategoryRepository categoryRepository = new MockCategoryRepository();

        public IEnumerable<Game> AllGames =>
            new List<Game>
            {
                new Game{GameId = 1, Name="Call of Duty", Price=59.95M, ShortDescription="Lorem Ipsum", LongDescription="Lorem Ipsum"},
                new Game{GameId = 2, Name="God of War", Price=59.95M, ShortDescription="Lorem Ipsum", LongDescription="Lorem Ipsum"},
                new Game{GameId = 3, Name="Halo", Price=59.95M, ShortDescription="Lorem Ipsum", LongDescription="Lorem Ipsum"},
                new Game{GameId = 4, Name="Elder Ring", Price=59.95M, ShortDescription="Lorem Ipsum", LongDescription="Lorem Ipsum"},
            };
        public IEnumerable<Game> GamesOfTheWeek { get; }

        public Game GetGameById(int gameId)
        {
            return AllGames.FirstOrDefault(p => p.GameId == gameId);
        }

    }
}
