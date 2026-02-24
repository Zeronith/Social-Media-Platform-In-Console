using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

internal class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepo;
    private readonly IUserService _userService;

    public AuthService(IUserService userService , IAuthRepository authRepo)
    {
        this._authRepo = authRepo;
        this._userService = userService;
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
        _authRepo.CurrentUser = user;
        return user;
    }

    public User? GetCurrentUser()
    {
        return _authRepo.CurrentUser;
    }

    public void SetCurrentUser(User? user)
    {
        _authRepo.CurrentUser = user;
    }
}
