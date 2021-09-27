using EmployeeInfo.Contracts.Entities;
using EmployeeInfo.API.Auth;
using EmployeeInfo.Contracts.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace EmployeeInfo.API.Controllers
{
    [Produces("application/json")]
    [EnableCors("MyPolicy")]
    [Route("api/TokenAuth")]
    public class TokenAuthController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<TokenAuthController> _logger;
        /// <summary>
        /// AddressTypesController contructor
        /// </summary>
        /// <param name="service"></param>
        /// <param name="logger"></param>
        public TokenAuthController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ILogger<TokenAuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody]User user)
        {
            var applicationUser = new ApplicationUser() { UserName = user.UserName, FirstName = user.ContactName, LastName = user.ContactName, Email = user.UserName };
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
                            requertAt = requestAt,
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

        [HttpPost]       
        public async Task<IActionResult> PostAsync([FromBody]User user)
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

        [Route("GetUserInfo")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            _logger.LogInformation("List User Info Asynchronously");

            var existingUser = await _userManager.FindByNameAsync(User.Identity.Name);

            if (existingUser != null)
            {
                return new OkObjectResult(existingUser);
            }
            return new NotFoundResult();
        }

        private  string GenerateToken(User user, DateTime expires)
        {
            var handler = new JwtSecurityTokenHandler();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "TokenAuth"),
                new[] {
                new Claim("ID", user.UserName.ToString())
                }
            );

            var securityToken =  handler.CreateToken(new SecurityTokenDescriptor
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