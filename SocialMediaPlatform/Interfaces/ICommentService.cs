using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Model;

namespace SocialMediaPlatform.Interfaces
{
    internal interface ICommentService
    {
        public Comment? CreateComment(Comment newComment);
        public List<Comment> GetCommentsByPostId(int postId);
    }
}
