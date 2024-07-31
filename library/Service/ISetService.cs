using library.Models;

namespace library.Service
{
    public interface ISetService
    {
        Task<List<SetModel>> GetAllSets();

        Task<SetModel> InsertSet(long ShelfId);

    }
}
