﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using YourVillage.Models;
using YourVillage.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace YourVillage
{
  public class Startup
  {
    public Startup(IWebHostEnvironment env)
    {
      var builder = new ConfigurationBuilder()
          .SetBasePath(env.ContentRootPath)
          .AddJsonFile("appsettings.json");
      Configuration = builder.Build();
    }
    public IConfigurationRoot Configuration { get; set; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc(option => option.EnableEndpointRouting = false);

      services.AddEntityFrameworkMySql()
        .AddDbContext<YourVillageContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

      services.AddDefaultIdentity<ApplicationUser>()
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<YourVillageContext>()
        .AddDefaultTokenProviders();

      services.AddScoped<IAuthorizationHandler, FamilyIsParentAuthorizationHandler>();

      // This is only available in .NetCore 3.0+
      services.AddAuthorization(options =>
      {
        options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
      });

      services.Configure<IdentityOptions>(options =>
        {
          options.Password.RequireDigit = false;
          options.Password.RequiredLength = 1;
          options.Password.RequireLowercase = false;
          options.Password.RequireNonAlphanumeric = false;
          options.Password.RequireUppercase = false;
          options.Password.RequiredUniqueChars = 0;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app)
    {
      app.UseStaticFiles();
      app.UseDeveloperExceptionPage();
      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}");
      });
      app.Run(async (context) =>
      {
        await context.Response.WriteAsync("Something went wrong!");
      });

    }



  }
}
