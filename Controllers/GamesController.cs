using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GamesPlatform.Controllers
{
    public class GamesController :Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGamesRepository _gamesRepository;
        private readonly ApplicationDbContext _applicationDbContext;

        public GamesController(ICategoryRepository categoryRepository, IGamesRepository gamesRepository, ApplicationDbContext applicationDbContext)
        {
            _categoryRepository = categoryRepository;
            _gamesRepository = gamesRepository;
            _applicationDbContext = applicationDbContext;

        }

        public ViewResult List(string category)
        {
            IEnumerable<Game> games;
            string currentCategory;
            //if category is null then current category is all games
            if (string.IsNullOrEmpty(category))
            {
                games = _gamesRepository.Games.OrderBy(g => g.GameID);
                currentCategory = "All Games";
            }
            else
            {
                //find games that matches category name argument
                games = _gamesRepository.Games.Where(c => c.Category.CategoryName == category);
                //find category that matches current category, with a null check that will display the category name
                currentCategory = _categoryRepository.Categories.FirstOrDefault(currentCategory => currentCategory.CategoryName == category)?.CategoryName;
            }

            return View(new GameListViewModel
            {
                Games = games,
                CurrentCategory = currentCategory
            });
        }


        public ViewResult Search(string searchString)
        {
            string _searchString = searchString;
            IEnumerable<Game> games;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(_searchString))
            {
                games = _gamesRepository.Games.OrderBy(p => p.GameID);
            }
            else
            {
                games = _gamesRepository.Games.Where(p => p.GameName.Contains(_searchString));
            }

            return View("~/Views/Games/List.cshtml", new GameListViewModel { Games = games, CurrentCategory = "All Games" });
        }

        public ViewResult Details(int gameId)
        {
            var game = _gamesRepository.GetGamesById(gameId);
            if (game == null)
            {
                return View("~/Views/Error/Error.cshtml");
            }
            return View(game);
        }


        public IActionResult hol()
        {
            return View();
        }

    }
}
