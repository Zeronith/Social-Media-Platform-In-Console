using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Interfaces
{
    internal interface IPostService
    {
        public BasePost? CreatePost(BasePost post);
        public BasePost? GetPostById(int id);
        public List<BasePost> GetPostsByUserId(int userId);
        public void ScrollNewsFeed();
    }
}
