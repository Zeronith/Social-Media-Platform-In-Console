using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Models.Abstract;
using SocialMediaPlatform.Models.Concrete;
using SocialMediaPlatform.Ports.ServicePorts;

namespace SocialMediaPlatform.Adapters.ServiceAdapters
{
    internal class NewsFeedService : INewsFeedService
    {
        private readonly IReactionService reactionSvc;
        private readonly IPostService postSvc;
        private readonly ICommentService commentSvc;
        private readonly IAuthService authSvc;
        private readonly IUserService userSvc;

        public NewsFeedService(IPostService postSvc, ICommentService commentSvc , IAuthService authSvc , IUserService userSvc , IReactionService reactionSvc) {
            this.reactionSvc = reactionSvc;
            this.postSvc = postSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
            this.userSvc = userSvc;
        }
        public void ScrollNewsFeed()
        {
            if (postSvc.NumberOfPosts == 0)
            {
                Console.WriteLine("Newsfeed is empty like the enguunbayar's brain");
                return;
            }

            foreach (BasePost post in postSvc.GetAllPosts().OrderByDescending(p => p.CreatedAt))
            {
                bool isContinue = true;
                Console.WriteLine($"\nOwner : {userSvc.GetById(post.OwnerId)!.Username} , \nPosted at : {post.CreatedAt} , \nReaction Count : {reactionSvc.GetReactionsByPostId(post.Id).Count} , \nContent : {post.Content}");
                while (isContinue)
                {
                    int choice = Reader.ReadInt("\n1) React to the post \n2) See the comments \n3) Write comments \n4) See next post \n5) Exit from newsfeed\n");
                    switch (choice)
                    {
                        case 1:
                            int reactionChoice = Reader.ReadInt("\n1) LIKE \n2) LOVE \n3) HAHA \n4) CARE \n5) WOW \n6) SAD \n7) ANGRY\n");
                            reactionSvc.ReactToThePost(post.Id, Reaction.IntToReaction[reactionChoice]) ;
                            break;
                        case 2:
                            List<Comment> comments = commentSvc.GetCommentsByPostId(post.Id);
                            Console.WriteLine("\n_____COMMENT SECTION_____\n");
                            foreach (Comment comment in comments)
                            {
                                Console.WriteLine($"- {userSvc.GetById(comment.OwnerId)!.Username}: {comment.Content}");
                            }
                            break;
                        case 3:
                            string content = Reader.ReadString("\nPlease write your comment\n");
                            _ = commentSvc.CreateComment(new Comment(authSvc.CurrentUser!.Id, post.Id, content));
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
