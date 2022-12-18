using Microsoft.IdentityModel.Tokens;
using Authentication.Options;

namespace Authentication.Constants
{
    public class AuthConstants
    {
        public const string Key = "My-Super_Duper-Key";
        public const string Issuer = "ISSUER";
        public const string Audience = "AUDIENCE";
        public const string ClaimType = "UserId";
        public const string AuthHeaderName = "Authorization";
        public const string TokenPrefix = "Bearer";
        public static DateTime? GetTokenExpirationDate()
        {
            return DateTime.UtcNow.Add(TimeSpan.FromDays(1));
        }

        public static SigningCredentials GetSigningCredentials()
        {
            return new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
        }
    }
}
