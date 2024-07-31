using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class ShelfModel
    {
        [Key]
         public long Id { get; set; }
        [Required]
        public required float Height { get; set; }
        [Required]
        public required float Width { get; set; }
        
        public long LibraryId { get; set; }
        public LibraryModel? LibraryGenre { get; set; }
        public List<SetModel> Sets { get; set; } = [];



    }
}