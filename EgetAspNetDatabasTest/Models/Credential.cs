using System.ComponentModel.DataAnnotations;

namespace EgetAspNetDatabasTest.Models
{
	public class Credential
	{
		[Required(ErrorMessage = "Username is required")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Password is required"), DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
