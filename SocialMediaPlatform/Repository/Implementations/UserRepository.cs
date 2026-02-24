using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Repository.Implementations
{
    internal class UserRepository : IUserRepository
    {
        private readonly Dictionary<int, User> usersById = new();
        private readonly Dictionary<string, User> usersByUsername = new();
        public void AddUser(User user)
        {
            usersById[user.Id] = user;
            usersByUsername[user.Username] = user;
        }
        public User? GetById(int id)
        {
            usersById.TryGetValue(id, out User? user);
            return user;
        }
        public User? GetByUsername(string username)
        {
            usersByUsername.TryGetValue(username, out User? user);
            return user;
        }
        public bool UsernameExists(string username)
        {
            return usersByUsername.ContainsKey(username);
        }
    }
}
