using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaParadisoApi.Token
{
    public class HelperToken
    {
        private IConfiguration configuration;
        private String secretkey;
        private String issuer;
        private String audience;

        public HelperToken(IConfiguration configuration)
        {
            this.configuration = configuration;            
            this.audience = configuration["ApiAuth:Audience"];
            this.issuer = configuration["ApiAuth:Issuer"];
            this.secretkey = configuration["ApiAuth:SecretKey"];
        }
        
        private SymmetricSecurityKey GetKeyToken()
        {            
            byte[] data = Encoding.UTF8.GetBytes(this.secretkey);            
            return new SymmetricSecurityKey(data);
        }
        
        public Action<AuthenticationOptions> GetAuthOptions()
        {
            Action<AuthenticationOptions> authoptions =
                new Action<AuthenticationOptions>(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                });
            return authoptions;
        }
        
        public Action<JwtBearerOptions> GetJwtOptions()
        {
            Action<JwtBearerOptions> jwtoptions =
                new Action<JwtBearerOptions>(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = this.issuer,
                        ValidAudience = this.audience,
                        IssuerSigningKey = this.GetKeyToken()
                    };
                });
            return jwtoptions;
        }

    }
}
