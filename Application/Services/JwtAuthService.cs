using CardsServerD100923ER.Application.Interfaces;
using CardsServerD100923ER.Core.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CardsServerD100923ER.Application.Services
{
    public class JwtAuthService:IAuth
    {
        public string GenerateToken(User u)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("_id",u.Id),
                new Claim("isAdmin",u.IsAdmin.ToString()),
                new Claim("isBusiness",u.IsBusiness.ToString())
            };


            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SuperSecret"));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer:"CardsServer",
                audience:"CardReactApp",
                expires:DateTime.Now.AddDays(2),
                claims:claims,
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
