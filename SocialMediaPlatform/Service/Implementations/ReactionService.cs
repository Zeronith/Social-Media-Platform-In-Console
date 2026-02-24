using System.Collections.Generic;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Service.UseCases
{
    /// <summary>
    /// Reaction service.
    /// Пост дээр reaction нэмэх, reaction мэдээллийг авах use-case логик.
    /// Repository layer-тай харилцаж reaction өгөгдлийг удирдана.
    /// </summary>
    internal class ReactionService : IReactionService
    {
        /// <summary>
        /// Reaction repository.
        /// Reaction өгөгдлийг хадгалах болон унших storage layer.
        /// </summary>
        private readonly IReactionRepository reactRepo;

        /// <summary>
        /// Auth service.
        /// Одоогийн нэвтэрсэн хэрэглэгчийн мэдээллийг авах зориулалттай.
        /// </summary>
        private readonly IAuthService authSvc;

        /// <summary>
        /// Constructor.
        /// ReactionService-ийг auth service болон reaction repository-оор үүсгэнэ.
        /// </summary>
        /// <param name="authSvc">Auth service.</param>
        /// <param name="reactRepo">Reaction repository.</param>
        public ReactionService(IAuthService authSvc, IReactionRepository reactRepo)
        {
            this.reactRepo = reactRepo;
            this.authSvc = authSvc;
        }

        /// <summary>
        /// Тухайн пост дээр тухайн хэрэглэгч ямар reaction өгснийг авна.
        /// </summary>
        /// <param name="postId">Постын Id.</param>
        /// <param name="userId">Хэрэглэгчийн Id.</param>
        /// <returns>
        /// ReactionType буцаана.
        /// Reaction байхгүй бол null буцаана.
        /// </returns>
        public ReactionType? GetReactionByPostIdAndUserId(int postId, int userId)
        {
            return reactRepo.GetReactionByPostIdAndUserId(postId, userId);
        }

        /// <summary>
        /// Тухайн пост дээр өгөгдсөн бүх reaction-уудыг авна.
        /// </summary>
        /// <param name="postId">Постын Id.</param>
        /// <returns>
        /// Dictionary&lt;userId, ReactionType&gt; хэлбэрээр буцаана.
        /// key = хэрэглэгчийн Id.
        /// value = reaction төрөл.
        /// </returns>
        public Dictionary<int, ReactionType> GetReactionsByPostId(int postId)
        {
            return reactRepo.GetReactionsByPostId(postId);
        }

        /// <summary>
        /// Тухайн хэрэглэгчийн өгсөн бүх reaction-уудыг авна.
        /// </summary>
        /// <param name="userId">Хэрэглэгчийн Id.</param>
        /// <returns>
        /// Dictionary&lt;postId, ReactionType&gt; хэлбэрээр буцаана.
        /// key = постын Id.
        /// value = reaction төрөл.
        /// </returns>
        public Dictionary<int, ReactionType> GetReactionsByUserId(int userId)
        {
            return reactRepo.GetReactionsByUserId(userId);
        }

        /// <summary>
        /// Одоогийн хэрэглэгч тухайн пост дээр reaction өгнө.
        /// AuthService-аас current user Id-г авч repository-д хадгална.
        /// </summary>
        /// <param name="postId">Reaction өгөх постын Id.</param>
        /// <param name="reaction">Reaction төрөл.</param>
        public void ReactToThePost(int postId, ReactionType reaction)
        {
            /// <summary>
            /// Одоогийн нэвтэрсэн хэрэглэгчийн Id-г авна.
            /// </summary>
            int userId = authSvc.GetCurrentUser()!.Id;

            /// <summary>
            /// Reaction repository-д reaction хадгална.
            /// </summary>
            reactRepo.ReactToThePost(userId, postId, reaction);
        }
    }
}