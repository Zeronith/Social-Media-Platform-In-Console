using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Model;
using SocialMediaPlatform.Service;

namespace SocialPlatform
{
    class Program
    {
        static CommentService commentSvc = new();
        static UserService userSvc = new();
        static AuthService authSvc = new(userSvc);
        static PostService postSvc = new(userSvc , commentSvc , authSvc);

        public static void  Main(string[] args)
        {
            userSvc.SetPostService(postSvc);
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
            postSvc.ScrollNewsFeed();
        }
        private static void GetMyProfile()
        {
            userSvc.GetMyProfile(authSvc.CurrentUser!.Id);
        }

        private static void CreatePost()
        {
            string content = Reader.ReadString("Content:");
            _ = postSvc.CreatePost(new Post(authSvc.CurrentUser!.Id, content));
            Console.WriteLine("Post Successfully created");
        }

    }
}