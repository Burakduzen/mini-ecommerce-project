using ETicaretAPI.Application.Abstractions.Token;
using ETicaretAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Token
{
    public class TokenHandler : ITokenHandler
    {
       readonly IConfiguration _configuraiton;

        public TokenHandler(IConfiguration configuraiton)
        {
            _configuraiton = configuraiton;
        }

        public Application.DTOs.Token CreateAccessToken(int second, AppUser user)
        {
            Application.DTOs.Token token = new();


            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuraiton["Token:SecurityKey"]));


            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            token.Expiration = DateTime.UtcNow.AddSeconds(second);

            JwtSecurityToken securityToken = new(
                audience: _configuraiton["Token:Audience"],
                issuer: _configuraiton["Token:Issuer"],
                expires: token.Expiration,
                notBefore: DateTime.UtcNow,
                signingCredentials: signingCredentials,
                claims: new List<Claim> { new(ClaimTypes.Name, user.UserName) }


                );

            JwtSecurityTokenHandler tokenHandler = new();
            token.AccessToken = tokenHandler.WriteToken(securityToken);

         //   string refreshToken = CreateRefreshToken();
            token.RefreshToken = CreateRefreshToken();
            return token;
            
            }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }
    }

    }

