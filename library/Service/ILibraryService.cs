using library.Models;

namespace library.Service
{
    public interface ILibraryService
    {
        Task<List<LibraryModel>> GetAllLibraries();
    }
}
