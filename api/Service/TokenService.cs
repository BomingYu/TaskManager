using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using api.Interfaces;
using api.Models;
using Microsoft.IdentityModel.Tokens;

namespace api.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(AppUser appUser)
        {
            //Create a Claim list for storing user detail(Name & Email)
            var claims = new List<Claim>{
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email , appUser.Email),
                new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.GivenName , appUser.UserName)
            };
            //Create Credentials, the creds is created by key and security algorithm of SHa...
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            //Create a token descriptor including subject, expire period, credentials, issuer and audience
            var tokenDescriptor = new SecurityTokenDescriptor{
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            //Decleare a new token obj
            var tokenHandler = new JwtSecurityTokenHandler();
            //Pass data into the new token obj, and paas the descriptor into it.
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //Return the token once the token created
            return tokenHandler.WriteToken(token);
        }
    }
}