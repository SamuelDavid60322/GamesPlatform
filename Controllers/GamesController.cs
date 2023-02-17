using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.Repositories;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GamesPlatform.Controllers
{
    public class GamesController :Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGamesRepository _gamesRepository;

        public GamesController(ICategoryRepository categoryRepository, IGamesRepository gamesRepository)
        {
            _categoryRepository = categoryRepository;
            _gamesRepository = gamesRepository;

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

        public IActionResult hol()
        {
            return View();
        }

    }
}
