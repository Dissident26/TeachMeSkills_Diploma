using Microsoft.IdentityModel.Tokens;
using System.Text;

using Authentication.Constants;

namespace Authentication.Options
{
    public class AuthOptions
    {
        private const string KEY = AuthConstants.Key;
        public const bool ValidateIssuer = true;
        public const bool ValidateAudience = true;
        public const bool ValidateLifetime = true;
        public const bool ValidateIssuerSigningKey = true;
        public const string ValidIssuer = AuthConstants.Issuer;
        public const string ValidAudience = AuthConstants.Audience;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }
    }
}
