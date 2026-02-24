using Microsoft.VisualBasic;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Helpers;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Service.UseCases
{
    /// <summary>
    /// Post service.
    /// Посттой холбоотой use-case логик.
    /// Repository-оос пост өгөгдлийг авах болон үүсгэх үйлдлийг дамжуулна.
    /// </summary>
    internal class PostService : IPostService
    {
        /// <summary>
        /// Post repository.
        /// Пост өгөгдлийг хадгалах болон унших storage layer.
        /// </summary>
        private readonly IPostRepository postRepo;

        /// <summary>
        /// Constructor.
        /// PostService-ийг post repository-оор үүсгэнэ.
        /// </summary>
        /// <param name="postRepo">Пост хадгалах repository.</param>
        public PostService(IPostRepository postRepo)
        {
            this.postRepo = postRepo;
        }

        /// <summary>
        /// Бүх постуудыг авна.
        /// Repository-оос бүх постуудыг дамжуулан буцаана.
        /// </summary>
        /// <returns>Бүх постуудын жагсаалт.</returns>
        public List<BasePost> GetAllPosts()
        {
            return postRepo.GetAllPosts();
        }

        /// <summary>
        /// Шинэ пост үүсгэнэ.
        /// Repository-д хадгалж, үүссэн постыг буцаана.
        /// </summary>
        /// <param name="newPost">Шинээр үүсгэх пост.</param>
        /// <returns>
        /// Амжилттай бол үүссэн пост.
        /// Амжилтгүй бол null.
        /// </returns>
        public BasePost? CreatePost(BasePost newPost)
        {
            return postRepo.CreatePost(newPost);
        }

        /// <summary>
        /// Тухайн хэрэглэгчийн бүх постуудыг авна.
        /// userId-аар repository-оос хайна.
        /// </summary>
        /// <param name="userId">Пост эзэмшигч хэрэглэгчийн Id.</param>
        /// <returns>Тухайн хэрэглэгчийн постууд.</returns>
        public List<BasePost> GetPostsByUserId(int userId)
        {
            return postRepo.GetPostsByUserId(userId);
        }

        /// <summary>
        /// Тодорхой постыг Id-аар авна.
        /// Repository-оос post.Id-аар хайна.
        /// </summary>
        /// <param name="id">Постын Id.</param>
        /// <returns>Post эсвэл null (олдсонгүй).</returns>
        public BasePost? GetPostById(int id)
        {
            return postRepo.GetPostById(id);
        }

        /// <summary>
        /// Нийт постын тоог авна.
        /// Repository дотор хадгалагдсан постын тоо.
        /// </summary>
        /// <returns>Нийт постын тоо.</returns>
        public int GetNumberOfPosts()
        {
            return postRepo.NumberOfPosts;
        }
    }
}