using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmployeeInfo.Services
{
    public class AuthorizationTokenService 
    {

        //private readonly UserManager<ApplicationUser> _userManager;
        //public async string GetAuthorizationToken()
        //{
        //   IdentityUser user 

        //    HttpContext. user;

        //    ApplicationUser applicationUser = await _userManager.GetUserAsync(HttpContext.User.Identity.Name);

        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:56622");
        //    var request = new HttpRequestMessage(HttpMethod.Post, "/path/to/post/to");

        //    var keyValues = new List<KeyValuePair<string, string>>();
        //    keyValues.Add(new KeyValuePair<string, string>("site", "http://www.google.com"));
        //    keyValues.Add(new KeyValuePair<string, string>("content", "This is some content"));

        //    request.Content = new FormUrlEncodedContent(keyValues);
        //    var response = await client.SendAsync(request);
        //}

    }
}
