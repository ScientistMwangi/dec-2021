using AutoMapper;
using EcommerceCore.DataLayer;
using EcommerceCore.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NG_Ecommerce.Helpers;
using NG_Ecommerce.Models;
using NG_Ecommerce.Models.Responses;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static EcommerceCore.Models.EcommerceConstants;

namespace NG_Ecommerce.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EcommerceDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly JwtSettings _jwtSettings;
        //private readonly U


        public AuthController(EcommerceDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<Role> roleManager, IOptionsSnapshot<JwtSettings> jwtSettings)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
        }

        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] UserDto userSignUpResource)
        {
            GenericResponse<UserDto> response = new GenericResponse<UserDto>();
            response.ReponseObject = userSignUpResource;
            if (!ModelState.IsValid)
            {
                response.Success = false;
                response.Message = "Invalid model";
                return Ok(response);
            }

            // Add roles manually

            //var role1 = new Role(); role1.Name = "Admin"; role1.NormalizedName = "ADMIN"; role1.ConcurrencyStamp = DateTime.Now.ToString();
            //var role2 = new Role(); role2.Name = "BasicUser"; role2.NormalizedName = "BASICUSER"; role2.ConcurrencyStamp = DateTime.Now.ToString();
            //await _roleManager.CreateAsync(role1);
            //await _roleManager.CreateAsync(role2);
            var user = _mapper.Map<UserDto, AppUser>(userSignUpResource);
            user.UserName = userSignUpResource.Email;
            user.EmailConfirmed = false;
            var userCreateResult = await _userManager.CreateAsync(user, userSignUpResource.Password);

            await _userManager.AddToRoleAsync(user, "BasicUser");
            if (userCreateResult.Succeeded)
            {
                // Send registration email for account activation
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmEmailLink = Url.Action("confirmemail", "Auth", new { userId = user.Id, token }, Request.Scheme);

                var contentFromConfig = EmailOperations.GetSubjectAndBoday(EmailTemplateType.Register, _context);
                string subj = "";
                string body = "";
                if(contentFromConfig.Count > 0)
                {
                    subj = contentFromConfig[0];
                    body = contentFromConfig[1];
                }
                body += "<br>" + confirmEmailLink;
                EmailOperations.EmailSend(_context, user.Email, subj, body);

                response.Success = true;
                response.Message = "Account created successfully";
                return Ok(response);
            }

            response.Message = userCreateResult.Errors.First().Description;
            response.Success = false;
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignIn(UserDto userLoginResource)
        {
            var user = await _userManager.FindByNameAsync(userLoginResource.Email);
            LoginResponse loginResponse;
            //.SingleOrDefault(u => u.UserName == userLoginResource.Email);
            if (user is null)
            {
                loginResponse = new LoginResponse { Message = "Wrong email or password ", Success = false };
                return Ok(loginResponse);
            }

            var userSigninResult = await _userManager.CheckPasswordAsync(user, userLoginResource.Password);
            var dbUser = await _userManager.FindByNameAsync(user.Email);
            if (!dbUser.EmailConfirmed)
            {
                loginResponse = new LoginResponse { Message = "Please confirm your email first ", Success = false };
                return Ok(loginResponse);
            }
           
            if (userSigninResult)
            {
                var roles = await _userManager.GetRolesAsync(user);
                loginResponse = new LoginResponse { Success = true, Role = string.Join(",", roles), Token = GenerateJwt(user, roles), Username = user.UserName };
                return Ok(loginResponse);
            }
            loginResponse = new LoginResponse { Message = "Wrong email or password ", Success = false };
            return Ok(loginResponse);
        }

        private string GenerateJwt(AppUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
            claims.AddRange(roleClaims);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_jwtSettings.ExpirationInDays));

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Issuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpGet("confirm-email")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {

            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(token))
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    NotFound(new { message = "user not found" });
                }
                else
                {
                    var result = await _userManager.ConfirmEmailAsync(user, token);
                    if (result.Succeeded)
                    {
                        return Ok(user.Email + " Account activated");
                    }
                    else
                    {

                        return NotFound();
                    }
                }
            }
            return NotFound();
        }

        [HttpGet("reset-password")]
        public async Task<IActionResult> ResetPassword(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            if (user == null || !user.EmailConfirmed)
                return NotFound("Unknown user");
            //user found update new password

            var newPassword = Helpers.Util.GetRandomPassword(8);
            //var result = await _userManager.ChangePasswordAsync(user, user.PasswordHash, newPassword);
            var resetPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, resetPassToken, newPassword);

            var contentFromConfig = EmailOperations.GetSubjectAndBoday(EmailTemplateType.ForgetPassword, _context);
            string subj = "";
            string body = "";
            if (contentFromConfig.Count > 0)
            {
                subj = contentFromConfig[0];
                body = contentFromConfig[1];
            }
            body += "<bold>" + newPassword+"  </bold>";
            EmailOperations.EmailSend(_context, user.Email, subj, body);

            return Ok("New password sent to your email");
        }
    }
}