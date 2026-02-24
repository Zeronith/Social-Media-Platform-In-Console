using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Repository.Interfaces
{
    public interface IAuthRepository
    {
        public User? CurrentUser { get; set; }
       
    }
}
