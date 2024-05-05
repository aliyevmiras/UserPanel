using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPanel.Models
{
	//[Index(nameof(User.Name), IsUnique = true)]
	public class User : IdentityUser<Guid>
	{
		// TODO: change names according to db conventions: camel-case or hyphen-case

		// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime RegDate { get; set; } = DateTime.UtcNow;

		[Required(ErrorMessage = "You forgot to type the password")]
		[DataType(DataType.Password)]
		public required string Password { get; set; }

		// using event to fire handler
		public DateTime? LastLoginDate { get; set; }
	}
}
