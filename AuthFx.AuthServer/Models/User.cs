using System.Collections.Generic;

namespace AuthFx.AuthServer.Models
{
    public class User
    {
        public User()
        {
        }

        public User(string userName, string displayName, string email)
            => (UserName, DisplayName, Email) = (userName, displayName, email);

        public string UserName { get; set; }
        
        public string DisplayName { get; set; }
        
        public string Email { get; set; }

        public List<Role> Roles { get; } = new List<Role>();
        
        public string PasswordHash { get; set; }

        public override string ToString() => UserName;

        public static readonly IEnumerable<User> MockUsers
            = new[]
            {
                new User("super", "Super User", "super@authfx.com"),
                new User("admin", "Admin User", "admin@authfx.com")
            };
    }
}