using Microsoft.VisualBasic;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Service.UseCases
{
    internal class PostService : IPostService
    {
        private readonly IPostRepository postRepo;
        private readonly IUserService userSvc;
        private readonly ICommentService commentSvc;
        private readonly IAuthService authSvc;

        public PostService(IUserService userSvc , ICommentService commentSvc , IAuthService authSvc , IPostRepository postRepo)
        {
            this.postRepo = postRepo;
            this.userSvc = userSvc;
            this.commentSvc = commentSvc;
            this.authSvc = authSvc;
        }
        public List<BasePost> GetAllPosts()
        {
            return postRepo.GetAllPosts();
           
        }
        public BasePost? CreatePost(BasePost newPost)
        {
           return postRepo.CreatePost(newPost);
        }
        public List<BasePost> GetPostsByUserId(int userId)
        {
            return postRepo.GetPostsByUserId(userId);
        }

        public BasePost? GetPostById(int id)
        {
            return postRepo.GetPostById(id);
        }

        public int GetNumberOfPosts()
        {
            return postRepo.NumberOfPosts;
        }
    }
}
