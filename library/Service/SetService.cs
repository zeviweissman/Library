using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class SetService : ISetService
    {
        private readonly ApplicationDBContext _dbContext;

        public SetService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public float TotalSetWidth(SetModel set) =>
            set.Books
            .Aggregate((float)0, (start, nextBook) => start + nextBook.Width);

        public async Task<List<SetModel>> GetAllSets() =>
            await _dbContext.set.ToListAsync();

        public Task<SetModel> InsertSet( ,long ShelfId)
        {

        }
    }
}
