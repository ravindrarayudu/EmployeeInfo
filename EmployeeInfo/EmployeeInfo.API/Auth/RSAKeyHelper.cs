using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Cryptography;

namespace EmployeeInfo.API.Auth
{
    public class RSAKeyHelper
    {
        public static RSAParameters GenerateKey()
        {
            using (var key = new RSACryptoServiceProvider(2048))
            {
                return key.ExportParameters(true);
            }
        }
    }
}
