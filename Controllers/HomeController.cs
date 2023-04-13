﻿using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using GamesPlatform.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GamesPlatform.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly IGamesRepository _gamesRepository;
        
        public HomeController(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                FeaturedGames = _gamesRepository.FeaturedGames,
                FreeGames = _gamesRepository.FreeGames
            };
            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Libary()
        {
            return View();
        }

        public IActionResult Error404(int? statusCode = null)
        {
            if (statusCode.HasValue && statusCode.Value == 404)
            {
                return View();
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}