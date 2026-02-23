using Microsoft.VisualBasic;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Models.Abstract;
using SocialMediaPlatform.Ports.ServicePorts;

namespace SocialMediaPlatform.Adapters.ServiceAdapters
{
    internal class PostService : IPostService
    {
        private static readonly Dictionary<int, BasePost> postById = new();
        private readonly Dictionary<int, List<BasePost>> postByOwnerId = new();
        public int NumberOfPosts => postById.Count;
        private readonly IUserService userSvc;
        private readonly ICommentService commentSvc;
        private readonly IAuthService authSvc;

        public PostService(IUserService userSvc , ICommentService commentSvc , IAuthService authSvc)
        {
            this.userSvc = userSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
        }
        public List<BasePost> GetAllPosts()
        {
            return postById.Values.ToList();
        }
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
        public List<BasePost> GetPostsByUserId(int userId)
        {
            if (postByOwnerId.TryGetValue(userId, out var posts))
            {
                return posts;
            }

            return new List<BasePost>();
        }

        public BasePost? GetPostById(int id)
        {
            if (postById.TryGetValue(id , out var posts))
            {
                return posts;
            }
            return null;
        }
    }
}
