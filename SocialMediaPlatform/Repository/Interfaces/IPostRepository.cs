using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Repository.Interfaces
{
    internal interface IPostRepository
    {
        public int NumberOfPosts { get; }
        public List<BasePost> GetAllPosts();
        public BasePost? CreatePost(BasePost post);
        public BasePost? GetPostById(int id);
        public List<BasePost> GetPostsByUserId(int userId);
    }
}
