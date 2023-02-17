using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using static System.Net.WebRequestMethods;

namespace GamesPlatform.Mocks
{
    public class MockGamesRepository : IGamesRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Game> Games => new List<Game>
            {
                new Game{
                    GameID=1,
                    GameName="Kick Ups",
                    Category = _categoryRepository.Categories.First(),
                    GameDescription= "The goal is simple, keep the ball in the air for the longest amount of time...",
                    Price=20.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = true
                },


                new Game{
                    GameID=2,
                    GameName="Amoeba Online",
                    Category = _categoryRepository.Categories.First(),
                    GameDescription= "Jump into the ultimate Single cell battle! Compete aganist 100 players or bots in this multiplayer game!",
                    Price=10.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = true
                },

                new Game{
                    GameID=3,
                    GameName="Reaction Test Game",
                    Category = _categoryRepository.Categories.First(),
                    GameDescription= "Test your reaction time and compare with others",
                    Price=50.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = true
                },

                new Game{
                    GameID=4,
                    GameName="Dungeon Deathmatch",
                    Category = _categoryRepository.Categories.First(),
                    GameDescription= "Dunegon Deathmatch is a fast paced top down multiplayer deathmatch game. Fight up to 8 players in this action game!",
                    Price=20.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = false
                },

                new Game{
                    GameID=5,
                    GameName="Dave Wakes Up",
                    GameDescription= "Dave wakes up is a short narrative top down 2d game. You play as Dave, trapped in a corpo world!",
                    Price=20.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = false
                },
                new Game{
                    GameID=6,
                    GameName="Tower Of Hanoi",
                    GameDescription= "Objective of the pizzle is to move the entire stack to another rod one at a time.",
                    Price=0.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = false,
                    IsFreeGame=true
                },

                new Game{
                    GameID=7,
                    GameName="High or Low",
                    GameDescription= "",
                    Price=0.00M,
                    GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                    IsFeaturedGame = false,
                    IsFreeGame=true
                },
            };
  
        public IEnumerable<Game> FeaturedGames { get; }
        public IEnumerable<Game> FreeGames { get; }

        public Game GetGamesById(int GameId)
        {
            throw new NotImplementedException();
        }
    }
}
