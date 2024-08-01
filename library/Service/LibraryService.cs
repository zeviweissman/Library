using library.Data;
using library.Models;
using library.View_Model;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<LibraryModel> InsertLibrary(string genre)
        {
            LibraryModel? generName = await _dbContext.library
                .FirstOrDefaultAsync(library => library.GenreName == genre);
            if (generName != null)
            {
                throw new Exception($"There is already a library in this {genre}");
            }
            LibraryModel library = new() { GenreName = genre };
            await _dbContext.library.AddRangeAsync(library);
            _dbContext.SaveChanges();
            return library;
        }
        public async Task<LibraryModel> InsertShelf(long id)
        {
            LibraryModel? ById = await _dbContext.library.FindAsync(id);
            if (ById == null)
            {
                throw new Exception("null");
            }

            return ById;
        }
        public async Task<ShelfModel> InsertShelfPost(ShelfVM shelf)
        {

            ShelfModel shelfModel = new()
            {
                Width = shelf.Width,
                Height = shelf.Height,
            };
            await _dbContext.shelf.AddAsync(shelfModel);
            _dbContext.SaveChanges();
            return shelfModel;
        }
        public async Task<ShelfModel> CreateShelf(ShelfVM shelfVM)
        {
            ShelfModel shelfModel = new()
            {
                Height = shelfVM.Height,
                Width = shelfVM.Width,
                LibraryId = shelfVM.LibraryId
            };
            await _dbContext.shelf.AddAsync(shelfModel);
            _dbContext.SaveChanges();
            return shelfModel;
        }

    }
}
