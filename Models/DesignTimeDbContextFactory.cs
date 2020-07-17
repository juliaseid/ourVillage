using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ourVillage.Models
{
  public class ourVillageContextFactory : IDesignTimeDbContextFactory<ourVillageContext>
  {

    ourVillageContext IDesignTimeDbContextFactory<ourVillageContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<ourVillageContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new ourVillageContext(builder.Options);
    }
  }
}