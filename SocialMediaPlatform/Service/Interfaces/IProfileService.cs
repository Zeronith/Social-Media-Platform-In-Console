using System;
using System.Collections.Generic;
using System.Text;

namespace SocialMediaPlatform.Ports.ServicePorts
{
    public interface IProfileService
    {
        public void GetMyProfile(int id);
    }
}
