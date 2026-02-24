using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Repository.Interfaces
{
    public interface IReactionRepository
    {
        public void ReactToThePost(int userId, int postId, ReactionType reaction);
        public ReactionType? GetReactionByPostIdAndUserId(int postId, int userId);
        public Dictionary<int, ReactionType> GetReactionsByPostId(int postId);
        public Dictionary<int, ReactionType> GetReactionsByUserId(int userId);
    }
}
