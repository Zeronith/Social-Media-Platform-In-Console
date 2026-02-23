using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Models.Concrete;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    internal interface ICommentService
    {
        public Comment? CreateComment(Comment newComment);
        public List<Comment> GetCommentsByPostId(int postId);
    }
}
