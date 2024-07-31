using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class BookModel
    {
        [Key]
        public long Id { get; set; }
        [Required, StringLength(100)]
        public required string BookName { get; set; }
        [Required]
        public required float Height { get; set; }
        [Required]
        public required float Width { get; set; }
        public required string GenreName { get; set; }
        public long SetId { get; set; }
        public SetModel? Set {get; set; }
    }
}