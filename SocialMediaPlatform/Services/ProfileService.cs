using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Services
{
    internal class ProfileService
    {
        private readonly IUserService userSvc;
        private readonly IPostService postSvc;

        public ProfileService(IUserService userSvc, IPostService postSvc)
        {
            this.userSvc = userSvc;
            this.postSvc = postSvc;
        }
        public void GetMyProfile(int id)
        {
            var user = userSvc.GetById(id);
            if (user == null) return;

            Console.WriteLine($"Username : {user.Username}");
            Console.WriteLine($"Age : {user.Age}");
            Console.WriteLine($"Joined at : {user.CreatedAt}");

            var posts = postSvc.GetPostsByUserId(id);

            foreach (var post in posts)
            {
                Console.WriteLine($"Content : {post.Content}");
                Console.WriteLine($"Created at : {post.CreatedAt}");
            }
        }
    }

}
