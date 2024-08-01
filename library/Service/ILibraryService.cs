using library.Models;
using library.View_Model;

namespace library.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetAllLibraries();

        Task<LibraryModel> InsertLibrary(string genre);

        Task<LibraryModel> InsertShelf(long id);
        Task<ShelfModel> CreateShelf(ShelfVM shelfVM);

    }
}
