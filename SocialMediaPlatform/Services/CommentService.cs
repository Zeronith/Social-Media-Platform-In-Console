using SocialMediaPlatform.Interfaces;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class CommentService : ICommentService
    {
        private readonly Dictionary<int, Comment> commentById = new();
        private readonly Dictionary<int, List<Comment>> commentsByPostId = new();
        private readonly Dictionary<int, List<Comment>> commentsByOwnerId = new();

        public Comment? CreateComment(Comment newComment)
        {
            if (commentById.ContainsKey(newComment.Id)) { return null; }
            commentById.Add(newComment.Id , newComment);
            if (!commentsByPostId.ContainsKey(newComment.PostId))
            {
                commentsByPostId[newComment.PostId] = new();
            }
            commentsByPostId[newComment.PostId].Add(newComment);
            if (!commentsByOwnerId.ContainsKey(newComment.OwnerId))
            {
                commentsByOwnerId[newComment.OwnerId] = new();
            }
            commentsByOwnerId[newComment.OwnerId].Add(newComment);
            return newComment;
        }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            if (commentsByPostId.TryGetValue(postId, out List<Comment>? comments))
            {
                return comments;
            }

            return new List<Comment>();
        }
    }
}
