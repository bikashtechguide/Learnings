using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace WebApplicationJWT
{
    public class TokenManager
    {
        private static string secret = "Secretkey/for/encription";
        public static string GenerateToken(string userName)
        {
            byte[] key = Convert.FromBase64String(secret);
            //SymmetricSecurityKey : Represents the abstract base class for all keys that are generated using symmetric algorithms.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(key);
            SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor
            {
                //ClaimIdentity is a list of claimns
                //Claim is https://stackoverflow.com/questions/21645323/what-is-the-claims-in-asp-net-identity
                // just take an example of single sign on of facebook to instagram, we fill user credentials
                // after authentication by trusted party, it provide the claims. which will be used by
                // relying party to create or view the site info.
                // claims are nothing but the information of user, could be username, email-id etc
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, userName) }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                // SigningCredentials : Represents the cryptographic key and security algorithms that are used to generate a digital signature.
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);
            return handler.WriteToken(token);

        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = tokenHandler.ReadJwtToken(token);
                if (jwtToken == null)
                    return null;
                byte[] key = Convert.FromBase64String(secret);
                TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
                SecurityToken securityToken;
                ClaimsPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
                return principal;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static string ValidateToken(string token)
        {
            string userName;
            ClaimsPrincipal claimsPrincipal = GetPrincipal(token);
            if (claimsPrincipal == null)
                return null;
            ClaimsIdentity claimsIdentity;
            try
            {
                claimsIdentity = (ClaimsIdentity)claimsPrincipal.Identity;
                Claim claimUserName = claimsIdentity.FindFirst(ClaimTypes.Name);
                userName = claimUserName.Value;
                return userName;    
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}