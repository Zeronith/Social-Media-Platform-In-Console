using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Models.Abstract
{
    internal abstract class BasePost
    {
        public BasePost( int UserId, string content)
        {
            Id = IdGenerator.NextId();
            OwnerId = UserId;
            Content = content;
            CreatedAt = DateTime.Now;
        }
        public int Id { get ; set; }
        public int OwnerId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
