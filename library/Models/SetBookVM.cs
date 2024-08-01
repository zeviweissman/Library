using System.ComponentModel.DataAnnotations;

namespace library.Models
{
    public class SetBookVM
        
    {
        public long Id { get; set; }
        [Required, StringLength(100)]

        public string SetName { get; set; }
      
        [Required, StringLength(100)]
        public required string BookName { get; set; }
        [Required]
        public required float Height { get; set; }
        [Required]
        public required float Width { get; set; }
        [Required]
        public required string GenreName { get; set; }
        
    }
}
