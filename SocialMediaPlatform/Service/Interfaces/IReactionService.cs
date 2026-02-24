using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    internal interface IReactionService
    {
        public void ReactToThePost(int postId, ReactionType reaction);
        public ReactionType? GetReactionByPostIdAndUserId(int postId, int userId);
        public Dictionary<int, ReactionType> GetReactionsByPostId(int postId);
        public Dictionary<int, ReactionType> GetReactionsByUserId(int userId);
    }
}
