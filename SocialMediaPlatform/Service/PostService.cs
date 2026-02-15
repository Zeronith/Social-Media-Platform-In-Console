using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class PostService
    {
        private readonly Dictionary<int, Post> postById = new();
        private readonly Dictionary<int, List<Post>> postByOwnerId = new();

        private readonly UserService userSvc;
        private readonly CommentService commentSvc;
        private readonly AuthService authSvc;

        public PostService(UserService userSvc , CommentService commentSvc , AuthService authSvc)
        {
            this.userSvc = userSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
        }
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
        public List<Post> GetPostsByUserId(int userId)
        {
            if (postByOwnerId.TryGetValue(userId, out var posts))
            {
                return posts;
            }

            return new List<Post>();
        }

        public Post? GetPostById(int id)
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
                Console.WriteLine("Newsfeed is empty like the creater brain");
                return;
            }
            foreach (Post post in postById.Values)
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
