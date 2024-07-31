using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    [Index(nameof(GenreName), IsUnique = true)]

    public class LibraryModel
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(100)]
        public required string GenreName { get; set; }

        public List<ShelfModel> Shelves { get; set; } = [];
    }
}
