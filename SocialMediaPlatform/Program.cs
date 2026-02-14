using SocialMediaPlatform.Helper;
using SocialMediaPlatform.Model;

namespace SocialPlatform
{
    class Program
    {
        static UserService userSvc = new UserService();
        static AuthService authSvc = new AuthService(userSvc);
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
            ShowMenu();
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
            int choice = Reader.ReadInt("1) My Profile \n  2) Scroll NewsFeed \n 3) Create Post ");
            switch(choice)
            {
                case 1:
                    MyProfile();
                    break;
                case 2:
                    ScrollNewsFeed();
                    break;
                case 3:
                    CreatePost();
                    break;
            }
        }
       
    }
}