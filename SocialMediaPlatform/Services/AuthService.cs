using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;


internal class AuthService : IAuthService
{
    private readonly IUserService _userService;
    public User? CurrentUser { get;  set; }

    public AuthService(IUserService userService)
    {
        _userService = userService;
    }
    public bool SignUp(string username, string password, int age)
    {
        if (age < 13) return false;
        if (_userService.UsernameExists(username)) return false;

        User newUser = new User(username, password, age);
        _userService.AddUser(newUser);
        return true;
    }
    public User? Login(string username, string password)
    {
        User? user = _userService.GetByUsername(username);
        if (user == null || user.Password != password) return null;
        CurrentUser = user;
        return user;
    }
}
