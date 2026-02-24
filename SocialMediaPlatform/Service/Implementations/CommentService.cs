using SocialMediaPlatform.Domain;
using SocialMediaPlatform.Ports.ServicePorts;

namespace SocialMediaPlatform.Service.UseCases
{
    /// <summary>
    /// Comment service.
    /// Коммент үүсгэх, postId-оор комментуудыг авах логик.
    /// Дотоод хадгалалт: in-memory Dictionary.
    /// </summary>
    internal class CommentService : ICommentService
    {
        /// <summary>
        /// CommentById.
        /// comment.Id → Comment.
        /// Давхардсан Id-г хурдан шалгах, comment-ийг id-оор шууд авах зориулалттай.
        ///// </summary>
        private readonly Dictionary<int, Comment> commentById = new();
        /// <summary>
        /// CommentsByPostId.
        /// post.Id → List&lt;Comment&gt;.
        /// Тухайн постын бүх комментуудыг хурдан авах зориулалттай.
        /// </summary>
        private readonly Dictionary<int, List<Comment>> commentsByPostId = new();

        /// <summary>
        /// CommentsByOwnerId.
        /// owner.Id → List&lt;Comment&gt;.
        /// Тухайн хэрэглэгчийн бичсэн бүх комментуудыг хурдан авах зориулалттай.
        /// </summary>
        private readonly Dictionary<int, List<Comment>> commentsByOwnerId = new();

        /// <summary>
        /// Коммент үүсгэнэ.
        /// - comment.Id давхцвал null буцаана.
        /// - commentById, commentsByPostId, commentsByOwnerId дээр зэрэг нэмнэ.
        /// </summary>
        /// <param name="newComment">
        /// Шинээр үүсгэх коммент.
        /// Id/PostId/OwnerId нь зөв бөглөгдсөн байх ёстой.
        /// </param>
        /// <returns>
        /// Амжилттай бол үүссэн Comment-ийг буцаана.
        /// Id давхцвал null буцаана.
        /// </returns>
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

        /// <summary>
        /// Тухайн postId-д хамаарах бүх комментуудыг буцаана.
        /// Коммент байхгүй бол хоосон List буцаана.
        /// </summary>
        /// <param name="postId">Комментуудыг авах постын Id.</param>
        /// <returns>Комментуудын жагсаалт (байхгүй бол хоосон).</returns>
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
