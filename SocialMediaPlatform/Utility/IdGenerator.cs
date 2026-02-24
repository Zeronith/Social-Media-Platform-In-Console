using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaPlatform.Helper
{
    public class IdGenerator
    {
        public static int _currentId = 0;
        public static int NextId()
        {
            return ++_currentId;
        }
    }
}
