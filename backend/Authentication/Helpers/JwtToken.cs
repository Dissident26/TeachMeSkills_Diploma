using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Authentication.Constants;
using Microsoft.AspNetCore.Http;

namespace Authentication.Helpers
{
    public class JwtToken
    {
        public static JwtSecurityToken GetToken(List<Claim> claims)
        {
            return new JwtSecurityToken(
                            issuer: AuthConstants.Issuer,
                            audience: AuthConstants.Audience,
                            claims: claims,
                            expires: AuthConstants.GetTokenExpirationDate(),
                            signingCredentials: AuthConstants.GetSigningCredentials()
                            );
        }
        public static int GetUserIdFromToken(IHeaderDictionary headers)
        {
            JwtSecurityToken token = GetValidToken(headers);
            string userId = token.Claims.First(claim => claim.Type == AuthConstants.ClaimType).Value;

            return int.Parse(userId);
        }
        private static JwtSecurityToken GetValidToken(IHeaderDictionary headers) {
            string authHeader = headers[AuthConstants.AuthHeaderName];
            var handler = new JwtSecurityTokenHandler();

            if (authHeader == null || !authHeader.StartsWith(AuthConstants.TokenPrefix))
            {
                throw new Exception(); // ???
            }

            return handler.ReadJwtToken(authHeader?.Substring(AuthConstants.TokenPrefix.Length)); //??
        }
    }
}
