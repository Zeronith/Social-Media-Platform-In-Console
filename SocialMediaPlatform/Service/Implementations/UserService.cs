using SocialMediaPlatform.Service;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;


/// <summary>
/// User service.
/// Хэрэглэгчийн мэдээлэлтэй ажиллах use-case логик.
/// Repository layer руу дамжуулж user нэмэх, хайх үйлдлүүдийг гүйцэтгэнэ.
/// </summary>
public class UserService : IUserService
{
    /// <summary>
    /// User repository.
    /// User өгөгдлийг хадгалах/унших storage layer.
    /// </summary>
    private readonly IUserRepository repo;
    /// <summary>
    /// Constructor.
    /// UserService-ийг user repository-оор үүсгэнэ.
    /// </summary>
    /// <param name="repo">User repository.</param>
    public UserService(IUserRepository repo)
    {
        this.repo = repo;
    }

    /// <summary>
    /// Шинэ хэрэглэгч нэмнэ.
    /// Repository-д хадгална.
    /// </summary>
    /// <param name="user">Нэмэх хэрэглэгч.</param>
    public void AddUser(User user)
    {
        repo.AddUser(user);
    }

    /// <summary>
    /// Username давхцаж байгаа эсэхийг шалгана.
    /// </summary>
    /// <param name="username">Шалгах username.</param>
    /// <returns>true: давхцсан. false: давхцаагүй.</returns>
    public bool UsernameExists(string username)
    {
        return repo.UsernameExists(username);
    }

    /// <summary>
    /// Username-оор хэрэглэгч авах.
    /// </summary>
    /// <param name="username">Хайх username.</param>
    /// <returns>User эсвэл null (олдсонгүй).</returns>
    public User? GetByUsername(string username)
    {
        return repo.GetByUsername(username);
    }

    /// <summary>
    /// Id-аар хэрэглэгч авах.
    /// </summary>
    /// <param name="id">Хайх user Id.</param>
    /// <returns>User эсвэл null (олдсонгүй).</returns>
    public User? GetById(int id)
    {
        return repo.GetById(id);
    }
}