using System.Collections.Generic;

namespace AuthFx.AuthServer.Models
{
    public class AppUser
    {
        public AppUser()
        {
        }

        public AppUser(string userName, string displayName, string email)
            => (UserName, DisplayName, Email) = (userName, displayName, email);

        public string UserName { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Email { get; set; }

        public List<Role> Roles { get; } = new List<Role>();
        
        public string PasswordHash { get; set; }

        public override string ToString() => UserName;

        public static readonly IEnumerable<AppUser> MockUsers
            = new[]
            {
                new AppUser("super", "Super User", "super@authfx.com"),
                new AppUser("admin", "Admin User", "admin@authfx.com")
            };
    }
}