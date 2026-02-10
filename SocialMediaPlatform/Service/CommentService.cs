using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Service
{
    internal class CommentService
    {
        private readonly Dictionary<int, Comment> commentById = new();
        private readonly Dictionary<int, List<Comment>> commentByPostId = new();
        private readonly Dictionary<int, List<Comment>> commentByOwnerId = new();

        public Comment? CreateComment(Comment newComment)
        {
            if (commentById.ContainsKey(newComment.Id)) { return null; }
            commentById.Add(newComment.Id , newComment);
            if (!commentByPostId.ContainsKey(newComment.PostId))
            {
                commentByPostId[newComment.PostId] = new();
            }
            commentByPostId[newComment.PostId].Add(newComment);
            if (!commentByOwnerId.ContainsKey(newComment.OwnerId))
            {
                commentByOwnerId[newComment.OwnerId] = new();
            }
            commentByOwnerId[newComment.OwnerId].Add(newComment);
            return newComment;
        }
    }
}
