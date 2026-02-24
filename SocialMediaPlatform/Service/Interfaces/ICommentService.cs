using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Domain;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    public interface ICommentService
    {
        public Comment? CreateComment(Comment newComment);
        public List<Comment> GetCommentsByPostId(int postId);
    }
}
