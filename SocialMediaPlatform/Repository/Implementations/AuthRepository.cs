using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Repository.Implementations
{
    internal class AuthRepository : IAuthRepository
    {
        public User? CurrentUser { get; set; }
    }
}
