using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Ports.ServicePorts;

namespace SocialMediaPlatform.Service.UseCases
{
    /// <summary>
    /// NewsFeed service.
    /// Newsfeed харуулах, постуудыг scroll хийх, reaction болон comment үйлдлийг удирдана.
    /// </summary>
    public class NewsFeedService : INewsFeedService
    {
        /// <summary>
        /// Reaction service.
        /// Пост дээр reaction нэмэх болон reaction тоо авах.
        /// </summary>
        private readonly IReactionService reactionSvc;

        /// <summary>
        /// Post service.
        /// Бүх постуудыг авах, постын тоо авах.
        /// </summary>
        private readonly IPostService postSvc;

        /// <summary>
        /// Comment service.
        /// Коммент үүсгэх болон постын комментуудыг авах.
        /// </summary>
        private readonly ICommentService commentSvc;

        /// <summary>
        /// Auth service.
        /// Одоогийн нэвтэрсэн хэрэглэгчийг авах.
        /// </summary>
        private readonly IAuthService authSvc;

        /// <summary>
        /// User service.
        /// User мэдээллийг Id-оор авах.
        /// </summary>
        private readonly IUserService userSvc;

        /// <summary>
        /// Constructor.
        /// NewsFeedService-ийг шаардлагатай service-үүдээр үүсгэнэ.
        /// </summary>
        /// <param name="postSvc">Post service.</param>
        /// <param name="commentSvc">Comment service.</param>
        /// <param name="authSvc">Auth service.</param>
        /// <param name="userSvc">User service.</param>
        /// <param name="reactionSvc">Reaction service.</param>
        public NewsFeedService(
            IPostService postSvc,
            ICommentService commentSvc,
            IAuthService authSvc,
            IUserService userSvc,
            IReactionService reactionSvc)
        {
            this.reactionSvc = reactionSvc;
            this.postSvc = postSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
            this.userSvc = userSvc;
        }

        /// <summary>
        /// Newsfeed scroll хийх.
        /// - Бүх постуудыг CreatedAt-аар буурах дарааллаар харуулна.
        /// - User reaction хийх боломжтой.
        /// - User comment харах боломжтой.
        /// - User comment бичих боломжтой.
        /// - Дараагийн пост руу шилжих боломжтой.
        /// - Newsfeed-ээс гарах боломжтой.
        /// </summary>
        public void ScrollNewsFeed()
        {
            if (postSvc.GetNumberOfPosts() == 0)
            {
                Console.WriteLine("Newsfeed is empty");
                return;
            }
            
            foreach (BasePost post in postSvc
                .GetAllPosts()
                .OrderByDescending(p => p.CreatedAt))
            {
                bool isContinue = true;

                Console.WriteLine(
                    $"\nOwner : {userSvc.GetById(post.OwnerId)!.Username}" +
                    $" , \nPosted at : {post.CreatedAt}" +
                    $" , \nReaction Count : {reactionSvc.GetReactionsByPostId(post.Id).Count}" +
                    $" , \nContent : {post.Content}");

                while (isContinue)
                {
                    int choice = Reader.ReadInt(
                        "\n1) React to the post" +
                        "\n2) See the comments" +
                        "\n3) Write comments" +
                        "\n4) See next post" +
                        "\n5) Exit from newsfeed\n");

                    switch (choice)
                    {
                        case 1:
                            int reactionChoice = Reader.ReadInt(
                                "\n1) LIKE" +
                                "\n2) LOVE" +
                                "\n3) HAHA" +
                                "\n4) CARE" +
                                "\n5) WOW" +
                                "\n6) SAD" +
                                "\n7) ANGRY\n");

                            reactionSvc.ReactToThePost(
                                post.Id,
                                Reaction.IntToReaction[reactionChoice]);
                            break;

                        case 2:
                            List<Comment> comments =
                                commentSvc.GetCommentsByPostId(post.Id);

                            Console.WriteLine("\n_____COMMENT SECTION_____\n");

                            foreach (Comment comment in comments)
                            {
                                Console.WriteLine(
                                    $"- {userSvc.GetById(comment.OwnerId)!.Username}: {comment.Content}");
                            }
                            break;

                        case 3:
                            string content =
                                Reader.ReadString("\nPlease write your comment\n");

                            _ = commentSvc.CreateComment(
                                new Comment(
                                    authSvc.GetCurrentUser()!.Id,
                                    post.Id,
                                    content));

                            Console.WriteLine("Successfully added comments");
                            break;

                        case 4:
                            isContinue = false;
                            break;

                        case 5:
                            return;

                        default:
                            break;
                    }
                }
            }
        }
    }
}