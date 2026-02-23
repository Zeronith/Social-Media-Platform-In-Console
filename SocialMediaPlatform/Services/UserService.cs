using SocialMediaPlatform.ServicePorts;
using SocialMediaPlatform.Model;
using SocialMediaPlatform.Service;

internal class UserService : IUserService
{
    private readonly Dictionary<int, User> usersById = new();
    private readonly Dictionary<string, User> usersByUsername = new();
    public void AddUser(User user)
    {
        usersById[user.Id] = user;
        usersByUsername[user.Username] = user;
    }
    public bool UsernameExists(string username)
    {
        return usersByUsername.ContainsKey(username);
    }
    public User? GetByUsername(string username)
    {
        usersByUsername.TryGetValue(username, out User? user);
        return user;
    }
    public User? GetById(int id)
    {
        usersById.TryGetValue(id, out User? user);
        return user;
    }
}
