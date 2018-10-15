using LoginAPI.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAPI.Helpers
{
    public class TokenHelper
    {
        public static void createToken(HttpResponse response, long userId, long roleId, string secret, int sessionExpiration)
        {
            //Set issued at date
            DateTime issuedAt = DateTime.UtcNow;
            //set the time when it expires
            DateTime expires = DateTime.UtcNow.AddMinutes(sessionExpiration);

            var tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();

            // Add userId
            claims.Add(new Claim(Constants.UserIdKey, userId.ToString()));
            // Add roleId
            claims.Add(new Claim(Constants.RoleIdKey, roleId.ToString()));

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims);

            var now = DateTime.UtcNow;
            var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the jwt
            var token =
                (JwtSecurityToken)
                    tokenHandler.CreateJwtSecurityToken(subject: claimsIdentity, notBefore: issuedAt, expires: expires, signingCredentials: signingCredentials);
            var tokenString = tokenHandler.WriteToken(token);

            response.Headers.Add("Access-Control-Expose-Headers", "Authorization");
            response.Headers.Add("Authorization", "Bearer " + tokenString);
        }

    }
}