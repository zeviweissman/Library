using library.Models;

namespace library.Service
{
    public interface ISetService
    {
        Task<List<SetModel>> GetAllSets();

        Task<(SetModel set, string? message)> InsertSet(SetModel set);

    }
}
