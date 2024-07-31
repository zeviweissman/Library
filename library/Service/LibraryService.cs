using library.Data;
using library.Models;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class LibraryService : ILibraryService
    {
        private readonly ApplicationDBContext _dbContext;

        public LibraryService(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task<List<LibraryModel>> GetAllLibraries() =>
            await _dbContext.library.ToListAsync();
        
    }
}
