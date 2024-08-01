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
        static Exception NoRoomException = new("no room on shelf please create new shelf");

        static string shortMessage = "Book added succefully but One of the books is shorter than the shelf";
        static string regularMessage = "Book added succefully";
        public static float VacancyOnShelf(ShelfModel shelf) =>
             shelf.Sets
            .Aggregate((float)shelf.Width, (start, nextSet) => start - TotalSetWidth(nextSet));
        
        public static bool ShelfHasRoom(ShelfModel shelf, SetModel set)  =>
            VacancyOnShelf(shelf) >= TotalSetWidth(set);
        public static bool ShelfIsHigh(ShelfModel shelf, SetModel set) =>
            shelf.Height >= MaxSetHeight(set);
        public static string ShortBookMessage(ShelfModel shelf, SetModel set) =>
            shelf.Height - MinSetHeight(set) > 10 ? shortMessage : regularMessage;
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

        public static bool BookFitsInShelf(ShelfModel shelf, SetModel set) => ShelfHasRoom(shelf, set) && ShelfIsHigh(shelf, set); 
        





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
                .FirstOrDefault(shelf => BookFitsInShelf(shelf, set));
            
            if (shelf == null)
            {
                throw NoRoomException;
            }
            set.ShelfId = shelf.Id;
            var message = ShortBookMessage(shelf, set);          
            var res = await _dbContext.set.AddAsync(set);
            await _dbContext.SaveChangesAsync();
            return (res.Entity, message);

        }
    }
}
