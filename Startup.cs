using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using YourVillage.Models;

namespace YourVillage
{
  public class Startup
  {
    public Startup(IHostingEnvironment env)
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
      services.AddMvc();

      services.AddEntityFrameworkMySql()
        .AddDbContext<YourVillageContext>(options => options
        .UseMySql(Configuration["ConnectionStrings:DefaultConnection"]));

      services.AddDefaultIdentity<ApplicationUser>()
      .AddRoles<IdentityRole>()
      .AddEntityFrameworkStores<YourVillageContext>()
      .AddDefaultTokenProviders();

      //This is only available in .NetCore 3.0+
      // services.AddAuthorization(options =>
      // {
      //   options.FallbackPolicy = new AuthorizationPolicyBuilder()
      //   .RequireAuthenticatedUser()
      //   .Build();
      // });

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

      // ConfigureAuth(app);
      createRolesandUsers();
    }

    private void createRolesandUsers()
    {

      var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
      var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


      // In Startup iam creating first Admin Role and creating a default Admin User     
      if (!roleManager.RoleExists("Admin"))
      {

        // first we create Admin rool    
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Admin";
        roleManager.Create(role);

        //Here we create a Admin super user who will maintain the website                   

        var user = new ApplicationUser();
        user.UserName = "shanu";
        user.Email = "syedshanumcain@gmail.com";

        string userPWD = "A@Z200711";

        var chkUser = UserManager.Create(user, userPWD);

        //Add default User to Role Admin    
        if (chkUser.Succeeded)
        {
          var result1 = UserManager.AddToRole(user.Id, "Admin");

        }
      }

      // creating Creating Manager role     
      if (!roleManager.RoleExists("Manager"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Manager";
        roleManager.Create(role);

      }

      // creating Creating Employee role     
      if (!roleManager.RoleExists("Employee"))
      {
        var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
        role.Name = "Employee";
        roleManager.Create(role);

      }
    }

  }
}
