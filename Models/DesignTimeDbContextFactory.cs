using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace YourVillage.Models
{
  public class YourVillageContextFactory : IDesignTimeDbContextFactory<YourVillageContext>
  {

    YourVillageContext IDesignTimeDbContextFactory<YourVillageContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<YourVillageContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new YourVillageContext(builder.Options);
    }
  }
}