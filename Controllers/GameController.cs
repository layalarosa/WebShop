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
        public ViewResult List()
        {
            //ViewBag.CurrentCategory = "Action";

            //return View(_gameRepository.AllGames);
            GamesListViewModel gamesListViewModel = new GamesListViewModel();
            gamesListViewModel.Games = _gameRepository.AllGames;

            gamesListViewModel.CurrentCategory = "Action";
            return View(gamesListViewModel);
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
