using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;
using WebShop.ViewModels;

namespace WebShop.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;

        public GameController(IGameRepository gameRepository, ICategoryRepository categoryRepository)
        {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;

        }

        // GET: /<controller>/
        //public ViewResult List()
        //{
        //ViewBag.CurrentCategory = "Action";

        //return View(_gameRepository.AllGames);
        //GamesListViewModel gamesListViewModel = new GamesListViewModel();
        //gamesListViewModel.Games = _gameRepository.AllGames;

        //gamesListViewModel.CurrentCategory = "All Games";
        //return View(gamesListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Game> games;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                games = _gameRepository.AllGames.OrderBy(p => p.GameId);
                currentCategory = "All Games";
            }
            else
            {
                games = _gameRepository.AllGames.Where(p => p.Category.CategoryName == category)
                    .OrderBy(p => p.GameId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new GamesListViewModel
            {
                Games = games,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var game = _gameRepository.GetGameById(id);
            if (game == null)
                return NotFound();

            return View(game);
        }
    }
}
