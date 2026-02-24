using SocialMediaPlatform.Service;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Repository.Interfaces;

internal class UserService : IUserService
{
    private readonly IUserRepository repo;
    private readonly Dictionary<int, User> usersById = new();
    private readonly Dictionary<string, User> usersByUsername = new();
    public UserService(IUserRepository repo)
    {
        this.repo = repo;
    }
    public void AddUser(User user)
    {
        repo.AddUser(user);
    }
    public bool UsernameExists(string username)
    {
        return repo.UsernameExists(username);
    }
    public User? GetByUsername(string username)
    {
        return repo.GetByUsername(username);
    }
    public User? GetById(int id)
    {
        return repo.GetById(id);
    }
}
