using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Model;
using SocialMediaPlatform.Service;

namespace SocialMediaPlatform.Interfaces
{
    internal interface IUserService
    {
        public void AddUser(User user);
        public User? GetById(int id);

        public void SetPostService(IPostService postSvc);

        public void GetMyProfile(int id);
        public bool UsernameExists(string username);
        public User? GetByUsername(string username);

    }

}
