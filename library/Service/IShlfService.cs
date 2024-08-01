using library.Models;
using library.View_Model;

namespace library.Service
{
    public interface IShlfService
    {
        public Task<List<ShelfModel>> AllShelves();

        public Task<ShelfModel> iInsertShelf(ShelfVM shelfVM);
    }
}
