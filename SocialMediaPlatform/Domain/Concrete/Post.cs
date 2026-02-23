using System;
using System.Collections.Generic;
using System.Text;
using SocialMediaPlatform.Models.Abstract;

namespace SocialMediaPlatform.Models.Concrete
{
    internal class Post : BasePost
    {   public Post(int ownerId, string content) : base(ownerId, content){}
    }
}
