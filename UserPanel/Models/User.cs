using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPanel.Models
{
	public enum UserStatus
	{
		Active,
		Blocked
	}

	public class User : IdentityUser<Guid>
	{
		public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

		public DateTime LastLoginDate { get; set; } = DateTime.UtcNow;

        public UserStatus Status { get; set; } = UserStatus.Active;

	}
}
