using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPanel.Models
{
	//[Index(nameof(User.Name), IsUnique = true)]
	[Index(nameof(User.Email), IsUnique = true)]
	public class User
	{
		// TODO: change names according to db conventions: camel-case or hyphen-case
		[Key]
		public int Id { get; set; }

		public Guid Guid { get; set; } = Guid.NewGuid();

		//[Required]
		//public required string Name { get; set; }

		[Required]
		public required string Email { get; set; }

		[Required]
		public required string Password { get; set; }

		// [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime RegDate { get; set; } = DateTime.UtcNow;

		// using event to fire handler
		public DateTime? LastLoginDate { get; set; }
	}
}
