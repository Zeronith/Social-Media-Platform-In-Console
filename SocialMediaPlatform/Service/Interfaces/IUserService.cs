using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Service;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    internal interface IUserService
    {
        public void AddUser(User user);
        public User? GetById(int id);
        public bool UsernameExists(string username);
        public User? GetByUsername(string username);

    }

}
