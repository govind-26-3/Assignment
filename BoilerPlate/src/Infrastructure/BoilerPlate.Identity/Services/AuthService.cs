using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BoilerPlate.Application.Exceptions;
using BoilerPlate.Application.Interfaces.Identity;
using BoilerPlate.Application.Models.Identity;
using BoilerPlate.Identity.Context;
using BoilerPlate.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BoilerPlate.Identity.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<ApplicationUser> _userManager;
        readonly SignInManager<ApplicationUser> _signInManager;
        readonly JwtSettings _jwtSettings;
        readonly ApplicationIdentityDbContext _context;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings, ApplicationIdentityDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }
        public async Task<AuthResponse> Login(AuthRequest authRequest)
        {

            var user = await _userManager.FindByEmailAsync(authRequest.Email);
            AuthResponse response = new AuthResponse();
            if (user == null)
            {
                throw new NotFoundException($"User with Email: {authRequest.Email} not exists.");
            }
            var userPassword = await _signInManager.CheckPasswordSignInAsync(user, authRequest.Password, false);

            if (!userPassword.Succeeded)
            {
                throw new BadRequestException($"Password Credentials are wrong");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);


            if (user.RefreshTokens.Any(a => a.IsActive))
            {

                var activeRefreshToken = user.RefreshTokens.Where(a => a.IsActive == true).FirstOrDefault();
                response.RefreshToken = activeRefreshToken.Token;
                response.RefreshTokenExpiration = activeRefreshToken.Expires;
            }
            else
            {

                var refreshToken = GenerateRefreshToken();
                response.RefreshToken = refreshToken.Token;
                response.RefreshTokenExpiration = refreshToken.Expires;
                user.RefreshTokens.Add(refreshToken);
                _context.Update(user);
                _context.SaveChanges();
            }
            response.IsAuthenticated = true;
            response.Id = user.Id;
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);



            return response;
        }

        private RefreshToken GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var generator = new RNGCryptoServiceProvider())
            {
                generator.GetBytes(randomNumber);
                return new RefreshToken
                {
                    Token = Convert.ToBase64String(randomNumber),
                    Expires = DateTime.UtcNow.AddDays(10),
                    Created = DateTime.UtcNow
                };
            }
        }

        public async Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var response = new RefreshTokenResponse();
            var user = _context.Users.SingleOrDefault(u => u.RefreshTokens.Any(t => t.Token == request.Token));
            if (user == null)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token did not match any users.";
                return response;
            }
            var refreshToken = user.RefreshTokens.Single(x => x.Token == request.Token);

            if (!refreshToken.IsActive)
            {
                response.IsAuthenticated = false;
                response.Message = $"Token Not Active.";
                return response;
            }

            //Revoke Current Refresh Token
            refreshToken.Revoked = DateTime.Now;

            //Generate new Refresh Token and save to Database
            var newRefreshToken = GenerateRefreshToken();
            user.RefreshTokens.Add(newRefreshToken);
            _context.Update(user);
            await _context.SaveChangesAsync();

            //Generates new jwt
            response.IsAuthenticated = true;
            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            response.RefreshToken = newRefreshToken.Token;
            response.RefreshTokenExpiration = newRefreshToken.Expires;
            return response;
        }
        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            //Get User Information from Db
            var userClaims = await _userManager.GetClaimsAsync(user);
            //List of roles that user belongs To
            var roles = await _userManager.GetRolesAsync(user);
            //convert roles list into Claims
            //new Claim(claimTypes.Role,"Admin")

            var roleClaims = roles.Select(roles => new Claim(ClaimTypes.Role, roles)).ToList();
            //Create Claims
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("uid",user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials

                );
            return jwtSecurityToken;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest registrationRequest)
        {
            var user = new ApplicationUser
            {
                Email = registrationRequest.Email,
                FirstName = registrationRequest.FirstName,
                LastName = registrationRequest.LastName,
                UserName = registrationRequest.Email,
                EmailConfirmed = true
            };
            var result = await _userManager.CreateAsync(user, registrationRequest.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegistrationResponse() { UserId = user.Id };

            }
            else
            {
                var errorResult = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new BadRequestException($"{errorResult}");
            }
        }


    }
}
