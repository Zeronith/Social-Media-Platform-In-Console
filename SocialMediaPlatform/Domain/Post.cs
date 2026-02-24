using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaPlatform.Domain
{
    public class Post : BasePost
    {   public Post(int ownerId, string content) : base(ownerId, content){}
    }
}
