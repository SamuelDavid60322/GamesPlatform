using GamesPlatform.Models;

namespace GamesPlatform.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
