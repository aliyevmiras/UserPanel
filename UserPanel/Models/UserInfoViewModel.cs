namespace UserPanel.Models
{
    public class UserInfoViewModel
    {
        public required string Email { get; set; }

        public required string UserName { get; set; }

        public required DateTime RegistrationDate { get; set; }

        public required DateTime LastLoginDate { get; set; }

        public required UserStatus Status { get; set; }

        public required string[] Roles { get; set; }
    }
}
