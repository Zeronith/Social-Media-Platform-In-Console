using System;
using System.Collections.Generic;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class PostService
    {
        private readonly Dictionary<int, Post> postById = new();
        private readonly Dictionary<int, List<Post>> postByUserId = new();

        public Post? CreatePost(Post newPost)
        {
            if (newPost == null) return null;

            if (postById.ContainsKey(newPost.Id)) return null;

            postById.Add(newPost.Id, newPost);
            if (!postByUserId.ContainsKey(newPost.OwnerId))
            {
                postByUserId[newPost.OwnerId] = new List<Post>();
            }

            postByUserId[newPost.OwnerId].Add(newPost);

            return newPost;
        }
    }
}
