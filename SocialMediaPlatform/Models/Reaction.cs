using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Model
{
    public enum ReactionType {
        LIKE, LOVE, HAHA, CARE, WOW, SAD, ANGRY
    }
    internal class Reaction
    {
        public static Dictionary<int, ReactionType> IntToReaction = new Dictionary<int, ReactionType>
        {
            {1 , ReactionType.LIKE } ,
            {2 , ReactionType.LOVE } ,
            {3 , ReactionType.HAHA } ,
            {4 , ReactionType.CARE } ,
            {5 , ReactionType.WOW }  ,
            {6 , ReactionType.SAD }  ,
            {7 , ReactionType.ANGRY},
        };
        public Reaction( int ownerId, int postId, ReactionType type)
        {
            Id = IdGenerator.NextId();
            OwnerId = ownerId;
            PostId = postId;
            Type = type;
            CreatedAt = DateTime.Now;
        }
        public int Id { set; get; }
        public int OwnerId { set; get; }
        public int PostId { set; get; }
        public ReactionType Type { set; get; }
        public DateTime CreatedAt { set; get; }
    }
}
