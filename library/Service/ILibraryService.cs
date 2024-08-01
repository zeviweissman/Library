using library.Models;

namespace library.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetAllLibraries();

        Task<LibraryModel> InsertLibrary(string genre);

        Task<LibraryModel> InsertShelf(long id);
    }
}
