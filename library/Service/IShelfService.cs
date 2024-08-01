using library.Models;
using library.View_Model;

namespace library.Service
{
    public interface IShelfService
    {
      
        public Task<ShelfModel> CreateShelf(ShelfVM shelfVM);
    }
}
