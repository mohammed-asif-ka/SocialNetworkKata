﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkKata.Core.Service.Interface
{
    public interface IUserService
    {
        public void PostMessage(string username, string message);
    }
}
