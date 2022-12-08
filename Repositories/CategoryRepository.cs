using GamesPlatform.Data;
using GamesPlatform.Interfaces;
using GamesPlatform.Models;

namespace GamesPlatform.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CategoryRepository(ApplicationDbContext applicationDbContext) 
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Category> Categories => _applicationDbContext.Categories;
    }
}
