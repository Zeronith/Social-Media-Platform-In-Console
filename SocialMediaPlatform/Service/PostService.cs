using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class PostService
    {
        private readonly Dictionary<int, Post> postById = new();
        private readonly Dictionary<int, List<Post>> postByOwnerId = new();

        public Post? CreatePost(Post newPost)
        {
            if (postById.ContainsKey(newPost.Id)) return null;

            postById.Add(newPost.Id, newPost);
            if (!postByOwnerId.ContainsKey(newPost.OwnerId))
            {
                postByOwnerId[newPost.OwnerId] = new List<Post>();
            }

            postByOwnerId[newPost.OwnerId].Add(newPost);

            return newPost;
        }
    }
}
