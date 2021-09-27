using Microsoft.IdentityModel.Tokens;
using System;

namespace EmployeeInfo.API.Auth
{
    public class TokenAuthOption
    {
        public static string Audience { get; } = "eLift Quote Audience";
        public static string Issuer { get; } = "eLift Quote Issuer";
        public static RsaSecurityKey Key { get; } = new RsaSecurityKey(RSAKeyHelper.GenerateKey());
        public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        public static TimeSpan ExpiresSpan { get; } = TimeSpan.FromMinutes(40);
        public static string TokenType { get; } = "Bearer"; 
    }
}
