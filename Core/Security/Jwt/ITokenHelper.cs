using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
