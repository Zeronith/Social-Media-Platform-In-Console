

namespace SocialMediaPlatform.Service
{
    /// <summary>
    /// Profile service.
    /// Хэрэглэгчийн profile мэдээлэл болон тухайн хэрэглэгчийн постуудыг харуулах use-case логик.
    /// </summary>
    public class ProfileService
    {
        /// <summary>
        /// User service.
        /// Хэрэглэгчийн мэдээллийг Id-аар авах зориулалттай.
        /// </summary>
        private readonly UserService userSvc;

        /// <summary>
        /// Post service.
        /// Хэрэглэгчийн постуудыг авах зориулалттай.
        /// </summary>
        private readonly PostService postSvc;

        /// <summary>
        /// Constructor.
        /// ProfileService-ийг шаардлагатай service-үүдээр үүсгэнэ.
        /// </summary>
        /// <param name="userSvc">User service.</param>
        /// <param name="postSvc">Post service.</param>
        public ProfileService(UserService userSvc, PostService postSvc )
        {
            this.userSvc = userSvc;
            this.postSvc = postSvc;
        }

        /// <summary>
        /// Тухайн хэрэглэгчийн profile мэдээллийг харуулна.
        /// - Username
        /// - Age
        /// - CreatedAt
        /// - Мөн тухайн хэрэглэгчийн бүх постуудыг харуулна.
        /// </summary>
        /// <param name="id">Profile харах хэрэглэгчийн Id.</param>
        public void GetMyProfile(int id)
        {
            var user = userSvc.GetById(id);
            if (user == null) return;

            Console.WriteLine("_____MY PROFILE_____");
            Console.WriteLine($"Username : {user.Username}");
            Console.WriteLine($"Age : {user.Age}");
            Console.WriteLine($"Joined at : {user.CreatedAt}");
            //Console.WriteLine($"Followed by : {}");
            //Console.WriteLine($"Following : {}");

            var posts = postSvc.GetPostsByUserId(id);
            foreach (var post in posts)
            {
                Console.WriteLine($"Created by : {userSvc.GetById(post.OwnerId)!.Username}");
                Console.WriteLine($"Content : {post.Content}");
                Console.WriteLine($"Created at : {post.CreatedAt}");
            }
        }
    }
}