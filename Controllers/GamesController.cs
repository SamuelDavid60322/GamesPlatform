using GamesPlatform.Interfaces;
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

        public ViewResult List() 
        {
            var games = _gamesRepository.Games;
            GameListViewModel vm = new GameListViewModel();
            vm.Games = _gamesRepository.Games;
            vm.CurrentCategory = "Games Category";

            return View(vm);
        }
    }
}
