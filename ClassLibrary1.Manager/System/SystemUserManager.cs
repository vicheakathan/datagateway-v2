using ClassLibrary1.Core;
using ClassLibrary1.Core.Client.Authorize;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class SystemUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly ILogger<SystemUserManager> _logger;

        private readonly IConfiguration _configuration;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public SystemUserManager(UserManager<ApplicationUser> _userManager, ILogger<SystemUserManager> _logger, IConfiguration _configuration, SignInManager<ApplicationUser> _signInManager) 
        {
            this._userManager = _userManager;
            this._logger = _logger;
            this._configuration = _configuration;
            this._signInManager = _signInManager;
        }

        public async Task<ClientToken> Authorize(BaseCredential credential)
        {
            ApplicationUser user = await _userManager.FindByNameAsync(credential.Username);

            if (user == null)
            {
                _logger.LogWarning("Invalid username", credential);

                throw new UnauthorizedAccessException("Invalid username or passsword");
            }

            var resultSignIn = await _signInManager.PasswordSignInAsync(user, credential.Password, true, true);

            if (!resultSignIn.Succeeded)
            {
                _logger.LogWarning("Invalid password", credential);

                throw new UnauthorizedAccessException("Invalid username or passsword");
            }

            ClientToken token = await GenerateTokenAsync(user);

            return token;
        }
        public async Task<ClientToken> GenerateTokenAsync(ClaimsPrincipal user)
        {
            ApplicationUser currentUser = await _userManager.GetUserAsync(user);

            var token = await GenerateTokenAsync(currentUser);

            return token;

        }

        public async Task<ClientToken> GenerateTokenAsync(ApplicationUser user)
        {

            //TimeSpan expiredIn = TimeSpan.FromHours(2);
            TimeSpan expiredIn = TimeSpan.FromMinutes(1);

            var acessClaims = await GenerateUserClaimAsync(user);

            var refreshClaims = await GenerateUserClaimAsync(user, isRefreshToken: true);

            string accessToken = GenerateToken(acessClaims, expiredIn);

            string refreshToken = GenerateToken(refreshClaims, TimeSpan.FromDays(14));

            ClientToken token = new ClientToken()
            {
                ExpiredIn = (long)expiredIn.TotalSeconds,
                GrantType = JwtBearerDefaults.AuthenticationScheme,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };

            return token;

        }
        protected async Task<IEnumerable<Claim>> GenerateUserClaimAsync(ApplicationUser user, bool isRefreshToken = false)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(ClaimTypes.Sid, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Authentication, "True"));
            claims.Add(new Claim(ClaimTypes.Actor, "User"));

            if (isRefreshToken) return claims;

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        protected string GenerateToken(IEnumerable<Claim> claims, TimeSpan expiredIn)
        {

            var expiredDate = DateTime.Now.Add(expiredIn);

            var sign = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    SecurityAlgorithms.HmacSha512);

            JwtSecurityToken securityToken = new JwtSecurityToken(
               issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                claims: claims,
                expires: expiredDate,
                signingCredentials: sign);

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }
    }
}
