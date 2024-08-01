using library.Data;
using library.Models;
using library.View_Model;
using Microsoft.EntityFrameworkCore;

namespace library.Service
{
    public class ShlfService : IShlfService
    {
        private readonly ApplicationDBContext _context;

        public ShlfService(ApplicationDBContext context)
        {
            _context = context;
        }

       

        public Task<List<ShelfModel>> AllShelves(long id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ShelfModel>> AllShelves()
        {
            throw new NotImplementedException();
        }

        public async Task<ShelfModel> iInsertShelf(ShelfVM shelfVM)
        {

            ShelfModel shelf = new() { 
                Width = shelfVM.Width,
                Height = shelfVM.Height,
            };
            await _context.shelf.AddAsync(shelf);
            _context.SaveChanges();
            return shelf;
        }
    }
}
