    using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaPlatform.Model
{
    internal class Post : BasePost
    {   public Post(int ownerUserId, string content) : base(ownerUserId, content){}
    }
}
