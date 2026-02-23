using System.Collections.Generic;
using SocialMediaPlatform.Models.Concrete;
using SocialMediaPlatform.Ports.ServicePorts;

namespace SocialMediaPlatform.Adapters.ServiceAdapters
{
    internal class ReactionService : IReactionService
    {
        private readonly AuthService authSvc;
        private readonly Dictionary<(int postId, int userId), ReactionType> reactions = new();
        private readonly Dictionary<int, Dictionary<int, ReactionType>> reactionsByPostId = new(); // postId -> (userId -> reaction)
        private readonly Dictionary<int, Dictionary<int, ReactionType>> reactionsByUserId = new(); // userId -> (postId -> reaction)

        public ReactionService(AuthService authSvc)
        {
            this.authSvc = authSvc;
        }
        public ReactionType? GetReactionByPostIdAndUserId(int postId, int userId)
        {
            return reactions.TryGetValue((postId, userId), out var reaction)
                ? reaction
                : null;
        }
        public Dictionary<int, ReactionType> GetReactionsByPostId(int postId)
        {
            return reactionsByPostId.TryGetValue(postId, out var map)
                ? new Dictionary<int, ReactionType>(map)   
                : new Dictionary<int, ReactionType>();
        }
        public Dictionary<int, ReactionType> GetReactionsByUserId(int userId)
        {
            return reactionsByUserId.TryGetValue(userId, out var map)
                ? new Dictionary<int, ReactionType>(map)  
                : new Dictionary<int, ReactionType>();
        }
        public void ReactToThePost(int postId, ReactionType reaction)
        {
            int userId = authSvc.CurrentUser!.Id;
            reactions[(postId, userId)] = reaction;
            if (!reactionsByPostId.TryGetValue(postId, out var byUsers))
            {
                reactionsByPostId[postId] = new Dictionary<int, ReactionType>();
            }
            reactionsByPostId[postId][userId] = reaction;
            if (!reactionsByUserId.TryGetValue(userId , out var byPosts )) 
            {
                reactionsByUserId[userId] = new Dictionary<int, ReactionType>();
            }
            reactionsByUserId[userId][postId] = reaction;
        }
    }
}