using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Domain
{
    public class User
    {
        public User( string username, string password, byte age)
        {
            Id = IdGenerator.NextId();
            Username = username;
            Password = password;
            Age = age;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
