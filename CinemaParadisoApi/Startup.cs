using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaParadisoApi.Data;
using CinemaParadisoApi.Repositories;
using CinemaParadisoApi.Token;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CinemaParadisoApi
{
    public class Startup
    {
        public IConfiguration configuration { get; }
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            HelperToken helperToken = new HelperToken(this.configuration);
            services.AddDbContext<ICinemaContext, CinemaContext>(options => options.UseSqlServer(configuration.GetConnectionString("azureSqlServer")));
            services.AddTransient<IRepositoryCinephile, RepositoryCinephile>();
            services.AddAuthentication(helperToken.GetAuthOptions()).AddJwtBearer(helperToken.GetJwtOptions());
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
