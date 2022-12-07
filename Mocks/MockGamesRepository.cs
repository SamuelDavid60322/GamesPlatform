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
                GameImageUrl ="https://i2-prod.manchestereveningnews.co.uk/sport/football/article24985459.ece/ALTERNATES/s615/0_GettyImages-1413133364.jpg", },


            new Games{GameID=2, GameName="Mobile Games", 
                GameDescription= "Avaliable games to play on your mobile device"},
            new Games{GameID=3, GameName="Casino Games", 
                GameDescription= "Test your luck in these casino games"}
        };
        public IEnumerable<Games> FeaturedGames { get; set; }
        public IEnumerable<Games> Games { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Games GetGamesById(int GameId)
        {
            throw new NotImplementedException();
        }
    }
}
