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

        public static float VacancyOnShelf(ShelfModel shelf)=>
             shelf.Sets
            .Aggregate((float)100, (start, nextSet) => start - TotalSetWidth(nextSet));
            
        
        public static bool ShelfHasRoom(ShelfModel shelf, SetModel set)  => VacancyOnShelf(shelf) >= TotalSetWidth(set);
        public static bool ShelfIsHigh(ShelfModel shelf, SetModel set) => shelf.Height >= MaxSetHeight(set);

        public static string GetSetGenre(SetModel set) =>
            set.Books.First().GenreName;

        public static float TotalSetWidth(SetModel set) =>
            set.Books
            .Aggregate((float)0, (start, nextBook) => start + nextBook.Width);
        public static float MaxSetHeight(SetModel set) =>
            set.Books
            .Max(book => book.Height);

        public static float MinSetHeight(SetModel set) =>
            set.Books
            .Min(book => book.Height);

        public async Task<List<SetModel>> GetAllSets() =>
            await _dbContext.set.ToListAsync();

        public async Task<(SetModel set, string? message)> InsertSet(SetModel set)
        {
            
            var library = await _dbContext.library
                .Include(library => library.Shelves)
                .ThenInclude(shelves =>  shelves.Sets)
                .ThenInclude(sets => sets.Books)
                .FirstOrDefaultAsync(library => library.GenreName == GetSetGenre(set));
            

            var shelf = library.Shelves
                .FirstOrDefault(shelf => ShelfHasRoom(shelf, set) && ShelfIsHigh(shelf, set));            
            if (shelf == null)
            {
                throw new Exception("no room on shelf please create new shelf");
            }
            var message = shelf.Height - MinSetHeight(set) > 10 ? "One of the books is shorter than the shelf" : null;
            set.ShelfId = shelf.Id;
            var res = await _dbContext.set.AddAsync(set);
            await _dbContext.SaveChangesAsync();
            return (res.Entity, message);

        }
    }
}
