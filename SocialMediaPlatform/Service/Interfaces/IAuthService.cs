using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    internal interface IAuthService
    {
        public bool SignUp(string username, string password, int age);
        public User? Login(string username, string password);

        public User? GetCurrentUser();
        public void SetCurrentUser(User? user);

    }
}
