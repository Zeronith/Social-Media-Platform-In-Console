using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Repository.Implementations
{
    internal class PostRepository : IPostRepository
    {
        private static readonly Dictionary<int, BasePost> postById = new();
        private readonly Dictionary<int, List<BasePost>> postByOwnerId = new();
        public int NumberOfPosts => postById.Count;
        public BasePost? CreatePost(BasePost newPost)
        {
            if (postById.ContainsKey(newPost.Id)) return null;

            postById.Add(newPost.Id, newPost);
            if (!postByOwnerId.ContainsKey(newPost.OwnerId))
            {
                postByOwnerId[newPost.OwnerId] = new List<BasePost>();
            }
            postByOwnerId[newPost.OwnerId].Add(newPost);

            return newPost;
        }

        public List<BasePost> GetAllPosts()
        {
            return postById.Values.ToList(); 
        }

        public BasePost? GetPostById(int id)
        {
            if (postById.TryGetValue(id, out var posts))
            {
                return posts;
            }
            return null;
        }

        public List<BasePost> GetPostsByUserId(int userId)
        {
            if (postByOwnerId.TryGetValue(userId, out var posts))
            {
                return posts;
            }

            return new List<BasePost>();
        }
    }
}
