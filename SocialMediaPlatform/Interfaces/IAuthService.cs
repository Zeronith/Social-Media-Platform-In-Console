using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Interfaces
{
    internal interface IAuthService
    {
        public User? CurrentUser { get;  set; }
        public bool SignUp(string username, string password, int age);
        public User? Login(string username, string password);

    }
}
