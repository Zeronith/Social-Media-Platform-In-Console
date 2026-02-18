using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Model
{
    internal class Comment
    {
        public Comment( int ownerId, int postId, string content)
        {
            Id = IdGenerator.NextId();
            OwnerId = ownerId;
            PostId = postId;
            this.Content = content;
            CreatedAt = DateTime.Now;
        }
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set;}
    }
}
