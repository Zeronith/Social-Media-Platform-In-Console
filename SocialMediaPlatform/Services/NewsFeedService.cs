using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Services
{
    internal class NewsFeedService
    {
        private readonly IPostService postSvc;
        private readonly ICommentService commentSvc;
        private readonly IAuthService authSvc;
        private readonly IUserService userSvc;

        public NewsFeedService(IPostService postSvc, ICommentService commentSvc , IAuthService authSvc , IUserService userSvc) {
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
                Console.WriteLine($"Owner : {userSvc.GetById(post.OwnerId)!.Username} , Posted at : {post.CreatedAt} , Content : {post.Content}");
                while (isContinue)
                {
                    int choice = Reader.ReadInt("1) See the comments \n2) Write comments \n3) See next post");
                    switch (choice)
                    {
                        case 1:
                            List<Comment> comments = commentSvc.GetCommentsByPostId(post.Id);
                            Console.WriteLine("\nCOMMENT SECTION\n");
                            foreach (Comment comment in comments)
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
