using SocialMediaPlatform.Helper;

namespace SocialMediaPlatform.Models.Concrete
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
