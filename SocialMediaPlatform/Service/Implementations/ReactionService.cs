using System.Collections.Generic;
using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Ports.ServicePorts;
using SocialMediaPlatform.Repository.Interfaces;

namespace SocialMediaPlatform.Service.UseCases
{
    internal class ReactionService : IReactionService
    {
        private readonly IReactionRepository reactRepo;
        private readonly AuthService authSvc;
        public ReactionService(AuthService authSvc , IReactionRepository reactRepo)
        {
            this.reactRepo = reactRepo;
            this.authSvc = authSvc;
        }
        public ReactionType? GetReactionByPostIdAndUserId(int postId, int userId)
        {
            return reactRepo.GetReactionByPostIdAndUserId(postId , userId); ;
        }
        public Dictionary<int, ReactionType> GetReactionsByPostId(int postId)
        {
            return reactRepo.GetReactionsByPostId(postId);
        }
        public Dictionary<int, ReactionType> GetReactionsByUserId(int userId)
        {
            return reactRepo.GetReactionsByUserId(userId);
        }
        public void ReactToThePost(int postId, ReactionType reaction)
        {
            int userId = authSvc.GetCurrentUser()!.Id;
            reactRepo.ReactToThePost(userId , postId, reaction);
        }
    }
}