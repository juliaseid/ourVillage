using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ourVillage.Models
{
  public class ourVillageContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Address> Addresses { get; set; }
    public DbSet<Child> Children { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public ourVillageContext(DbContextOptions options) : base(options) { }
  }
}