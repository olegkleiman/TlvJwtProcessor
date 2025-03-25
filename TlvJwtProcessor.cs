using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace TlvJwtProcessor
{
    public class TlvJwtProcessor(string jwtString)
    {
        private readonly string _jwtString = jwtString;
        private readonly JwtSecurityTokenHandler tokenHandler = new();

        public async Task<ClaimsPrincipal?> Validate()
        {
            if (!tokenHandler.CanReadToken(_jwtString))
                return null;

            var jwtToken = tokenHandler.ReadJwtToken(_jwtString);

            var issuer = jwtToken.Issuer;
            var authenticationAuthority = issuer + ".well-known/openid-configuration";

            if (!tokenHandler.CanValidateToken)
                return null;

            ConfigurationManager<OpenIdConnectConfiguration> configurationManager =
                                new(authenticationAuthority,
                                    new OpenIdConnectConfigurationRetriever());
            var openIdConfig = await configurationManager.GetConfigurationAsync(); //.Result;

            TokenValidationParameters tokenParameters = new()
            {
                IssuerSigningKeys = openIdConfig.SigningKeys,
                ValidIssuer = openIdConfig.Issuer,

                ValidateIssuer = true,
                ValidateLifetime = true,

                ValidateIssuerSigningKey = false,
                ValidateAudience = false,
            };
            return tokenHandler.ValidateToken(_jwtString,
                                tokenParameters,
                                out _);
        }
    }

}
