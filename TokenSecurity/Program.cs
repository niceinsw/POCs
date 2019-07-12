using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace TokenSecurity
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var token = Security.GenerateToken("tester", 10);
            //string username;
            //var result = Security.ValidateToken(token, out username);

            var user = Security.AuthenticateJwtToken(token);

            Console.WriteLine($"Token: {token}");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public static class Security
    {
        private const string Secret = "BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string GenerateToken(string username, int expireMinutes = 20)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Name, username)
                    }),
                Expires = DateTime.UtcNow.AddMinutes(expireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(symmetricKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        public static bool ValidateToken(string token, out string username)
        {
            username = null;

            var simplePrincipal = GetPrincipal(token);

            var identity = simplePrincipal.Identities.FirstOrDefault() as ClaimsIdentity;
            //var identity = (ClaimsIdentity)simplePrincipal.Identities.FirstOrDefault();

            if (identity == null || !identity.IsAuthenticated)
                return false;

            var usernameClaim = identity.FindFirst(ClaimTypes.Name);

            username = usernameClaim?.Value;

            if (string.IsNullOrEmpty(username))
                return false;

            return true;
        }

        public static ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                    return null;

                string secret2 = "BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

                //var symmetricKey = Convert.FromBase64String(Secret);
                var symmetricKey = Convert.FromBase64String(secret2);

                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static IPrincipal AuthenticateJwtToken(string token)
        {
            string username;

            if (ValidateToken(token, out username))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                    //add more claims if required e.g. Roles etc
                };

                var identity = new ClaimsIdentity(claims, "Jwt");
                IPrincipal user = new ClaimsPrincipal(identity);

                return user;
            }
            return null;
        }
    }
}
