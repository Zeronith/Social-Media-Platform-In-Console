using SocialMediaPlatform.Model;


internal class AuthService
{
    private readonly UserService _userService;
    public User? CurrentUser { get; private set; }

    public AuthService(UserService userService)
    {
        _userService = userService;
    }
    public bool SignUp(string username, string password, int age)
    {
        if (age < 13) return false;
        if (_userService.UsernameExists(username)) return false;

        User newUser = new User(username, password, age);
        _userService.AddUser(newUser);

        CurrentUser = newUser;
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
