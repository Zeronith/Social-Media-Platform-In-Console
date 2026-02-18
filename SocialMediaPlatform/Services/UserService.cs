using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;
using SocialMediaPlatform.Service;

internal class UserService : IUserService
{
    private readonly Dictionary<int, User> usersById = new();
    private readonly Dictionary<string, User> usersByUsername = new();


    private IPostService? postSvc;

    public void SetPostService(IPostService postSvc)
    {
        this.postSvc = postSvc;
    }
    public void GetMyProfile(int id)
    {
        User? user = usersById[id];
        if (user == null)
        {
            return;
        }
        Console.WriteLine($"Username : {user.Username}\nAge : {user.Age}\nJoined at : {user.CreatedAt} ");
        List<BasePost> posts = postSvc!.GetPostsByUserId(user.Id);
        foreach(Post post in posts)
        {
            Console.WriteLine($"Owner : {usersById[post.OwnerId].Username} ,\nPosted at : {post.CreatedAt} , \nContent : {post.Content}");
        }

    }
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
