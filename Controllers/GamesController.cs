using GamesPlatform.Interfaces;
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

        public ViewResult List() 
        {
            var games = _gamesRepository.Games;
            return View(games);
        }
    }
}
