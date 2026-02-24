using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Repository.Implementations;
using SocialMediaPlatform.Repository.Interfaces;
using SocialMediaPlatform.Service.UseCases;
namespace SocialPlatform
{
    class Program
    {
        static UserRepository userRepo = new();
        static PostRepository postRepo = new();
        static ReactionRepository reactRepo = new();
        static AuthRepository authRepo = new();

        static CommentService commentSvc = new();
        static UserService userSvc = new(userRepo);
        static PostService postSvc = new(postRepo);
        static AuthService authSvc = new(userSvc , authRepo);
        static ReactionService reactionSvc = new(authSvc, reactRepo);
        static ProfileService profileSvc = new(userSvc, postSvc);
        static NewsFeedService newsFeedSvc = new(postSvc,commentSvc,authSvc,userSvc, reactionSvc);

        public static void  Main(string[] args)
        {
            RunApp();
        }
        private static void RunApp()
        {
            while(true)
            {
                Console.WriteLine("_____WELCOME TO THE NOBOOK_____");
                Console.WriteLine("1) Login");
                Console.WriteLine("2) Signup");
                Console.WriteLine("0) Exit");

                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Thank you for using NoBook");
                        return;
                    case 1:
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
            while (ShowMenu()){}
        }
        static void HandleSignup()
        {
            string username = Reader.ReadString("Username: ");
            string password = Reader.ReadString("Password: ");
            int age = Reader.ReadInt("Age: ");

            bool ok = authSvc.SignUp(username, password, age);
            Console.WriteLine(ok ? "Signup successful." : "Signup failed.");
        }
        static bool ShowMenu()
        {
            int choice = Reader.ReadInt("1) My Profile \n2) Scroll NewsFeed \n3) Create Post \n4) Log Out\n");
            switch(choice)
            {
                case 1:
                    GetMyProfile();
                    return true;
                case 2:
                    ScrollNewsFeed();
                    return true;
                case 3:
                    CreatePost();
                    return true;
                case 4:
                    LogOut();
                    return false;
                default:
                    return true;
            }
        }

        private static void LogOut()
        {
            authSvc.SetCurrentUser(null);
        }

        private static void ScrollNewsFeed() {
            newsFeedSvc.ScrollNewsFeed();
        }
        private static void GetMyProfile()
        {
            profileSvc.GetMyProfile(authSvc.GetCurrentUser()!.Id);
        }

        private static void CreatePost()
        {
            int typeOfPost = Reader.ReadInt("1) Reel\n2) Post \n");
            switch (typeOfPost)
            {
                case 1:
                    int durationInSeconds = Reader.ReadInt("Please enter reel duration :");
                    string reelContent = Reader.ReadString("Content: ");
                    _ = postSvc.CreatePost(new Reel(authSvc.GetCurrentUser()!.Id, reelContent, durationInSeconds));
                    Console.WriteLine("Reel Successfully created");
                    break;
                case 2:
                    string postContent = Reader.ReadString("Content:");
                    _ = postSvc.CreatePost(new Post(authSvc.GetCurrentUser()!.Id, postContent));
                    Console.WriteLine("Post Successfully created");
                    break;

            }

        }

    }
}