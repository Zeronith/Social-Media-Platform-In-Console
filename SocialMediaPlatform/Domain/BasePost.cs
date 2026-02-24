using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Domain
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

        public static bool operator == (BasePost a , BasePost b)
        {
            // Хэрвээ ижил object бол true буцаана .
            if (ReferenceEquals(a, b)) return true;
            // Хэрвээ 2-уулаа null бол false буцаана .
            if (a is null || b is null) return false;
            // Id-ийг харьцуулж буцаана .
            return a.Id == b.Id;
        }
        public static bool operator != (BasePost a , BasePost b)
        {
            // Negating the overloaded operator == 
            return !(a == b);
        }


    }
}
