using System.ComponentModel.DataAnnotations;

namespace EgetAspNetDatabasTest.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; } // Primärnyckel

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public List<Post> Posts { get; set; }
    }
}
