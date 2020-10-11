using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BooksLibrary.Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace BooksLibrary.API.Auth
{
    public class JwtTokenAuth
    {
        private readonly string _secretKey = "AG8CduXpDJpwMzqiB1Cmdg3aVOL4rqxjXYUjVrkzo7MEbFDWwQoVXN7lTP3bZDx";
        private readonly int _tokenLifetimeMinutes = 15;

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            var encodedKey = Encoding.ASCII.GetBytes(_secretKey);
            return new SymmetricSecurityKey(encodedKey);
        }

        public string GetToken(User user)
        {
            var now = DateTime.UtcNow;
            var expires = now.Add(TimeSpan.FromMinutes(_tokenLifetimeMinutes));

            var securityKey = new JwtTokenAuth().GetSymmetricSecurityKey();
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = GetClaims(user);

            var jwt = new JwtSecurityToken(
                notBefore: now,
                claims: claims,
                expires: expires,
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            yield return new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login);

            if (LibrarianRole.IsInRole(user))
                yield return new Claim(ClaimsIdentity.DefaultRoleClaimType, LibrarianRole.Name);

            if (ReaderRole.IsInRole(user))
                yield return new Claim(ClaimsIdentity.DefaultRoleClaimType, ReaderRole.Name);
        }
    }
}
