using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

using Authentication.Constants;

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
    }
}
