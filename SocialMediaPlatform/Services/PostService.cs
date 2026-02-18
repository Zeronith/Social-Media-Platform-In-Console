using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class PostService : IPostService
    {
        private readonly Dictionary<int, BasePost> postById = new();
        private readonly Dictionary<int, List<BasePost>> postByOwnerId = new();

        private readonly IUserService userSvc;
        private readonly ICommentService commentSvc;
        private readonly IAuthService authSvc;

        public PostService(IUserService userSvc , ICommentService commentSvc , IAuthService authSvc)
        {
            this.userSvc = userSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
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
        public void ScrollNewsFeed()
        {
            if (postById.Values.Count == 0)
            {
                Console.WriteLine("Newsfeed is empty like the enguunbayar's brain");
                return;
            }

            foreach (BasePost post in postById.Values.OrderByDescending(p => p.CreatedAt))
            {
                bool isContinue = true;
                Console.WriteLine($"Owner : {userSvc.GetById(post.OwnerId)!.Username} , Posted at : {post.CreatedAt} , Content : {post.Content}");
                while (isContinue)
                {
                    int choice = Reader.ReadInt("1) See the comments \n2) Write comments \n3) See next post");
                    switch (choice)
                    {
                        case 1:
                            List<Comment> comments = commentSvc.GetCommentsByPostId(post.Id);
                            Console.WriteLine("\nCOMMENT SECTION\n");
                            foreach(Comment comment in comments)
                            {
                                Console.WriteLine($"- {userSvc.GetById(comment.OwnerId)!.Username}: {comment.Content}");
                            }
                            break;
                        case 2:
                            string content = Reader.ReadString("Please enter your comment");
                            _ = commentSvc.CreateComment(new Comment(authSvc.CurrentUser!.Id, post.Id, content));
                            Console.WriteLine("Successfully added comments");
                            break;
                        case 3:
                            isContinue = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
