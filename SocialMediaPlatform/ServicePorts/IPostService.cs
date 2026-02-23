using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.ServicePorts
{
    internal interface IPostService
    {
        public int NumberOfPosts { get; }
        public List<BasePost> GetAllPosts();
        public BasePost? CreatePost(BasePost post);
        public BasePost? GetPostById(int id);
        public List<BasePost> GetPostsByUserId(int userId);
      
    }
}
