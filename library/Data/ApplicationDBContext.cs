using library.Models;
using library.Service;
using Microsoft.EntityFrameworkCore;

namespace library.Data
{
    public class ApplicationDBContext : DbContext
    {
        
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {
            
        }


        public DbSet<LibraryModel> library { get; set; }
        public DbSet<ShelfModel> shelf { get; set; }
        public DbSet<SetModel> set { get; set; }
        public DbSet<BookModel> book { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LibraryModel>()
                .HasMany(library => library.Shelves)
                .WithOne(shelf => shelf.LibraryGenre)
                .HasForeignKey(shelf => shelf.LibraryId)
                .OnDelete(DeleteBehavior.Cascade);          

            modelBuilder.Entity<ShelfModel>()
                .HasMany(shelf => shelf.Sets)
                .WithOne(set => set.Shelf)
                .HasForeignKey(set => set.ShelfId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SetModel>()
                 .HasMany(set => set.Books)
                 .WithOne(book => book.Set)
                 .HasForeignKey(book => book.SetId)
                 .OnDelete(DeleteBehavior.Cascade);

        }
        public DbSet<library.Models.SetBookVM> SetBookVM { get; set; } = default!;

    }
}
