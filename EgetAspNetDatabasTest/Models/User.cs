using System.ComponentModel.DataAnnotations;

namespace EgetAspNetDatabasTest.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primärnyckel

        [Required] // Markerar fältet som obligatoriskt
        // [Index(IsUnique = true)] // Använd detta om du vill göra Username unikt, kräver EF Core 5.0 eller senare
        public string Username { get; set; }

        [Required] // Markerar fältet som obligatoriskt
        public string Password { get; set; }

        public List<Post> Posts { get; set; }
    }
}
