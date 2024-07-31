using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace library.Models
{
    public class SetModel
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(100)]
        public required string SetName { get; set; }
        public long ShelfId { get; set; }
        public ShelfModel? Shelf { get; set; }
        public List<BookModel> Books { get; set; } = [];
       

        
    }
}