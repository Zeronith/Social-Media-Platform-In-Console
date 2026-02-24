using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

/// <summary>
///  Auth Service
///  Хэрэглэгч бүртгэл/нэвтрэлт , нэвтэрсэн байгаа хэрэглэгчийн төлвийг удирдана .
/// </summary>
internal class AuthService : IAuthService
{
    private readonly IAuthRepository _authRepo;
    private readonly IUserService _userService;
    /// <summary>
    /// Constructor .
    /// Auth Service нь байгуулагч дотроо IUserService болон IAuthRepository interface-ийг хэрэгжүүлсэн concrete class-ийг авна 
    /// </summary>
    /// <param name="userService">Хэрэглэгчийн Service хэрэглэгч нэмэх хасах зэрэг үйлдлийг хийнэ .</param>
    /// <param name="authRepo">Бүртгүүлэх , Нэвтрэх зэрэг үйлдлүүдийг хийнэ .</param>
    public AuthService(IUserService userService , IAuthRepository authRepo)
    {
        this._authRepo = authRepo;
        this._userService = userService;
    }
    /// <summary>
    /// Шинэ хэрэглэгчийг нэр , нууц үг , нас зэргийг авч үүсгэнэ .
    /// </summary>
    /// <param name="username">Нэр нь өмнө нь системд бүртгэлгүй байх ёстой </param>
    /// <param name="password">Системд нэвтрэхэд зориулсан нууц үг </param>
    /// <param name="age">Нас нь 12-оос эрс их байх хэрэгтэй </param>
    /// <returns></returns>
    public bool SignUp(string username, string password, int age)
    {
        if (age < 13) return false;
        if (_userService.UsernameExists(username)) return false;
        User newUser = new User(username, password, age);
        _userService.AddUser(newUser);
        return true;
    }
    /// <summary>
    /// Өгөгдсөн username болон password ашиглан хэрэглэгчийг нэвтрүүлэхийг оролдоно.
    /// </summary>
    /// <param name="username">
    /// Нэвтрэх гэж буй хэрэглэгчийн username. null байж болохгүй.
    /// </param>
    /// <param name="password">
    /// Тухайн username-д харгалзах нууц үг. null байж болохгүй.
    /// </param>
    public User? Login(string username, string password)
    {
        User? user = _userService.GetByUsername(username);
        if (user == null || user.Password != password) return null;
        _authRepo.CurrentUser = user;
        return user;
    }
    /// <summary>
    /// Нэвтрэсэн байгаа хэрэглэгчийн мэдээллийг авахад зориулсан функц
    /// </summary>
    /// <returns>Хэрвээ хэрэглэгч нэвтэрсэн байгаа бол тухайн хэрэглэгчийн мэдээллийг , нэвтрээгүй байгаа бол Null буцааж болзошгүй</returns>
    public User? GetCurrentUser()
    {
        return _authRepo.CurrentUser;
    }
    /// <summary>
    /// Нэвтэрсэний дараа хэрэглэгчийг тохируулна . 
    /// </summary>
    /// <param name="user"></param>
    public void SetCurrentUser(User? user)
    {
        _authRepo.CurrentUser = user;
    }
}
