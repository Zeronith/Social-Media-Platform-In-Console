using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Repository.Implementations
{
    public class AuthRepository : IAuthRepository
    {
        public User? CurrentUser { get; set; }
    }
}
