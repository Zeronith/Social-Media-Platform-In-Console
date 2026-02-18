using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Model;
using SocialMediaPlatform.Service;
using SocialMediaPlatform.Services;

namespace SocialPlatform
{
    class Program
    {
        static CommentService commentSvc = new();
        static UserService userSvc = new();
        static AuthService authSvc = new(userSvc);
        static PostService postSvc = new(userSvc , commentSvc , authSvc);
        static ProfileService profileSvc = new(userSvc, postSvc);
        static NewsFeedService newsFeedSvc = new(postSvc,commentSvc,authSvc,userSvc);

        public static void  Main(string[] args)
        {
            RunApp();
        }
        private static void RunApp()
        {
            while(true)
            {
                Console.WriteLine("WELCOME TO THE NOBOOK");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Signup");
                Console.WriteLine("0) Exit");

                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1 :
                        HandleLogin();
                        break;
                    case 2:
                        HandleSignup();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
        static void HandleLogin()
        {
            string username = Reader.ReadString("Username: ");
            string password = Reader.ReadString("Password: ");

            User? user = authSvc.Login(username, password);

            if (user == null)
            {
                Console.WriteLine("Invalid username or password.");
                return;
            }
            Console.WriteLine($"Logged in as {user.Username}");
            while (true)
            {
                ShowMenu();
            }
        }
        static void HandleSignup()
        {
            string username = Reader.ReadString("Username: ");
            string password = Reader.ReadString("Password: ");
            int age = Reader.ReadInt("Age: ");

            bool ok = authSvc.SignUp(username, password, age);
            Console.WriteLine(ok ? "Signup successful." : "Signup failed.");
        }
        static void ShowMenu()
        {
            int choice = Reader.ReadInt("1) My Profile \n2) Scroll NewsFeed \n3) Create Post ");
            switch(choice)
            {
                case 1:
                    GetMyProfile();
                    break;
                case 2:
                    ScrollNewsFeed();
                    break;
                case 3:
                    CreatePost();
                    break;
                default:
                    break;
            }
        }

        private static void ScrollNewsFeed() {
            newsFeedSvc.ScrollNewsFeed();
        }
        private static void GetMyProfile()
        {
            profileSvc.GetMyProfile(authSvc.CurrentUser!.Id);
        }

        private static void CreatePost()
        {
            int typeOfPost = Reader.ReadInt("1) Reel\n2) Post");
            switch (typeOfPost)
            {
                case 1:
                    int durationInSeconds = Reader.ReadInt("Please enter reel duration");
                    string reelContent = Reader.ReadString("Content:");
                    _ = postSvc.CreatePost(new Reel(authSvc.CurrentUser!.Id, reelContent, durationInSeconds));
                    Console.WriteLine("Reel Successfully created");
                    break;
                case 2:
                    string postContent = Reader.ReadString("Content:");
                    _ = postSvc.CreatePost(new Post(authSvc.CurrentUser!.Id, postContent));
                    Console.WriteLine("Post Successfully created");
                    break;

            }

        }

    }
}