using library.Data;
using library.Models;
using library.View_Model;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class ShelfService : IShelfService
    {
        private readonly ApplicationDBContext _context;

        public ShelfService(ApplicationDBContext context)
        {
            _context = context;
        }



        public async Task<ShelfModel> CreateShelf(ShelfVM shelfVM)
        {
            ShelfModel shelfModel = new()
            {
                Height = shelfVM.Height,
                Width = shelfVM.Width,
                LibraryId = shelfVM.LibraryId
            };
            await _context.shelf.AddAsync(shelfModel);
            _context.SaveChanges();
            return shelfModel;
        }


    }
}
