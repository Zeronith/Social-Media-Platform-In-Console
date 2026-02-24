using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Repository.Interfaces
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public bool UsernameExists(string username);
        public User? GetByUsername(string username);
        public User? GetById(int id);
    }
}
