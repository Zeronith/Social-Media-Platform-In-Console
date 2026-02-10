using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Model
{
    internal class User
    {
        public User( string username, string password, int age)
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
        public int Age { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
