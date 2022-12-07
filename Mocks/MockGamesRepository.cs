using GamesPlatform.Interfaces;
using GamesPlatform.Models;
using static System.Net.WebRequestMethods;

namespace GamesPlatform.Mocks
{
    public class MockGamesRepository : IGamesRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Games> AllGames => new List<Games>
        {
            new Games{
                GameID=1, 
                GameName="Kick Ups", 
                GameDescription= "The goal is simple, keep the ball in the air for the longest amount of time...",
                Price=20.00M,
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                IsFeaturedGame = "true"
            },


            new Games{GameID=2,                
                GameName="Amoeba Online",
                GameDescription= "Jump into the ultimate Single cell battle! Compete aganist 100 players or bots in this multiplayer game!",
                Price=10.00M,
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                IsFeaturedGame = "true"
            },

            new Games{GameID=3,                
                GameName="Reaction Test Game",
                GameDescription= "Test your reaction time and compare with others",
                Price=50.00M,
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                IsFeaturedGame = "true"
            },

            new Games{GameID=4,
                GameName="Dungeon Deathmatch",
                GameDescription= "Dunegon Deathmatch is a fast paced top down multiplayer deathmatch game. Fight up to 8 players in this action game!",
                Price=20.00M,
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                IsFeaturedGame = "false"
            },

            new Games{GameID=5,
                GameName="DDave Wakes Up",
                GameDescription= "Dave wakes up is a short narrative top down 2d game. You play as Dave, trapped in a corpo world!",
                Price=20.00M,
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                GameImageThumbnailUrl = "https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg",
                IsFeaturedGame = "false"
            },
        };
        public IEnumerable<Games> FeaturedGames { get; set; }
        public IEnumerable<Games> Games { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Games GetGamesById(int GameId)
        {
            throw new NotImplementedException();
        }
    }
}
