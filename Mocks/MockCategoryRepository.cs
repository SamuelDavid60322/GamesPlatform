using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Mocks
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories => new List<Category>
        {
            new Category{CategoryID=1, CategoryName="Web Games", CategoryDescription= "Available games you can play on your browser"},
            new Category{CategoryID=2, CategoryName="Mobile Games", CategoryDescription= "Avaliable games to play on your mobile device"},
            new Category{CategoryID=3, CategoryName="Casino Games", CategoryDescription= "Test your luck in these casino ga mes"},
            new Category{CategoryID=4, CategoryName="Free Games", CategoryDescription= "Enjoy these free games hand-picked by Gamesino!"}
        };
    }
}
