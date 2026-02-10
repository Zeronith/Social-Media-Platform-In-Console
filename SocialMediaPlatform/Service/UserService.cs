using SocialMediaPlatform.Model;

internal class UserService
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
}
