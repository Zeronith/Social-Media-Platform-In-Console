using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    internal interface IPostService
    {
        public List<BasePost> GetAllPosts();
        public BasePost? CreatePost(BasePost post);
        public BasePost? GetPostById(int id);
        public List<BasePost> GetPostsByUserId(int userId);
        public int GetNumberOfPosts();
      
    }
}
