using EmployeeInfo.API.Auth;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using EmployeeInfo.Contracts.Entities;

namespace EmployeeInfo.API.Controllers
{
    [Authorize]
    [Route("api/Users")]
    [EnableCors("MyPolicy")]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<UsersController> _logger;
        public UsersController(
         UserManager<ApplicationUser> userManager,
         SignInManager<ApplicationUser> signInManager, ILogger<UsersController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> AuthenticateAsync([FromBody]User user)
        {
            _logger.LogInformation("List all Authentication Token Asynchronously");
            var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, lockoutOnFailure: false);
            if (signInResult.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                var requestAt = DateTime.Now;
                var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                var token = GenerateToken(user, expiresIn);
                var existingUser = await _userManager.FindByNameAsync(user.UserName);
                var result = new RequestResult
                {
                    Msg = "User Authenticated Successfully",
                    State = RequestState.Success,
                    Data = new
                    {
                        requestat = requestAt,
                        expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                        tokeyType = TokenAuthOption.TokenType,
                        id = existingUser.Id,
                        username = existingUser.UserName,
                        firstName = existingUser.FirstName,
                        lastName = existingUser.LastName,
                        accessToken = token
                    }
                };
                return new OkObjectResult(result);
            }
            else
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Username or password is invalid"
                }));
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]User user)
        {
            var applicationUser = new ApplicationUser() { UserName = user.UserName, Email = user.UserName };
            var userCreatioResult = await _userManager.CreateAsync(applicationUser, user.Password);
            if (userCreatioResult.Succeeded)
            {
                var signInResult = await _signInManager.PasswordSignInAsync(user.UserName, user.Password, true, lockoutOnFailure: false);
                if (signInResult.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    var requestAt = DateTime.Now;
                    var expiresIn = requestAt + TokenAuthOption.ExpiresSpan;
                    var token = GenerateToken(user, expiresIn);
                    var result = new RequestResult
                    {
                        Msg = "User Registered Successfully",
                        State = RequestState.Success,
                        Data = new
                        {
                            requestat = requestAt,
                            expiresIn = TokenAuthOption.ExpiresSpan.TotalSeconds,
                            tokeyType = TokenAuthOption.TokenType,
                            accessToken = token
                        }
                    };
                    return new OkObjectResult(result);
                }
                else
                {
                    return new OkObjectResult((new RequestResult
                    {
                        State = RequestState.Failed,
                        Msg = "Username or password is invalid"
                    }));
                }
            }
            else
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "User Creation Failed"
                }));

            }
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllAsync()
        {
            _logger.LogInformation("List all users Asynchronously");
            var users = await _userManager.Users.ToListAsync();
            if (users != null && users.Any())
            {
                var result = new RequestResult
                {
                    Msg = "Users retrieved Successfully",
                    State = RequestState.Success,
                    Data = users
                };
                return new OkObjectResult(result);
            }
            else
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Unable to Retrieve Users"
                }));
            }
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetByIdAsync(string userId)
        {
            _logger.LogInformation("Get User Information by User Id Asynchronously");
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = new RequestResult
                {
                    Msg = "User retrieved Successfully",
                    State = RequestState.Success,
                    Data = user
                };
                return new OkObjectResult(result);
            }
            return new OkObjectResult((new RequestResult
            {
                State = RequestState.Failed,
                Msg = "Unable to Retrieve User by UserId"
            }));
        }

        [HttpGet]
        [Route("GetUserByUserName")]
        public async Task<IActionResult> GetByNameAsync(string userName)
        {
            _logger.LogInformation("Get User Information by User Id Asynchronously");
            var user = await _userManager.FindByNameAsync(userName);
            if (user != null)
            {
                var result = new RequestResult
                {
                    Msg = "User retrieved Successfully",
                    State = RequestState.Success,
                    Data = user
                };
                return new OkObjectResult(result);
            }
            return new OkObjectResult((new RequestResult
            {
                State = RequestState.Failed,
                Msg = "Unable to Retrieve User by UserId"
            }));
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateAsync([FromBody]ApplicationUser user)
        {

            _logger.LogInformation("Update User Information by User Id Asynchronously");
            var applicationUser = await _userManager.FindByNameAsync(user.UserName);
            if (applicationUser == null)
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Unable to Retrieve User"
                }));
            }
            if (applicationUser.Email != user.Email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(applicationUser, user.Email);
                if (!setEmailResult.Succeeded)
                {
                    return new OkObjectResult((new RequestResult
                    {
                        State = RequestState.Failed,
                        Msg = "Unable to set email Id for user" + user.UserName
                    }));
                }
            }

            if (applicationUser.FirstName != user.FirstName)
            {
                applicationUser.FirstName = user.FirstName;
            }
            if (applicationUser.LastName != user.LastName)
            {
                applicationUser.LastName = user.LastName;
            }


            await _userManager.UpdateAsync(applicationUser);
            await _signInManager.RefreshSignInAsync(applicationUser);
            return new OkObjectResult((new RequestResult
            {
                State = RequestState.Failed,
                Msg = "Your profile has been updated" + user.UserName
            }));
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<IActionResult> DeleteAsync(string username)
        {
            _logger.LogInformation("Delete User Information by User Id Asynchronously");
            var applicationUser = await _userManager.FindByNameAsync(username);
            if (applicationUser == null)
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Unable to Retrieve User"
                }));
            }

            var identityResult = await _userManager.DeleteAsync(applicationUser);

            if (identityResult.Succeeded)
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Success,
                    Msg = "profile has been delete" + applicationUser.UserName
                }));
            }
            else
            {
                return new OkObjectResult((new RequestResult
                {
                    State = RequestState.Failed,
                    Msg = "Profile deletion failed for " + applicationUser.UserName
                }));
            }
        }

        private string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[] {
                new Claim("ID", user.UserName.ToString())
                }
            );

            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = TokenAuthOption.Issuer,
                Audience = TokenAuthOption.Audience,
                SigningCredentials = TokenAuthOption.SigningCredentials,
                Subject = identity,
                Expires = expires
            });
            return handler.WriteToken(securityToken);
        }

    }
}