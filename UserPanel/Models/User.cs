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
		public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

		public DateTime LastLoginDate {  get; set; }

		[Required(ErrorMessage = "Please provide a valid password")]
		[DataType(DataType.Password)]
        [Display(Prompt = "Must have at least 1 character")]
        public required string Password { get; set; }

		[Required(ErrorMessage = "Please provide a valid email address")]
        [EmailAddress(ErrorMessage = "Please provide a valid email address")]
        [DataType(DataType.EmailAddress)]
        [Display(Prompt = "johndoe@xxxxx.xxx")]
        public required string EmailAddress { get; set; }

	}
}
