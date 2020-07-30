using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YourVillage.Models
{
  public class YourVillageContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Child> Children { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Family> Families { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<ChildNote> ChildNotes { get; set; }
    public DbSet<ChildProfile> ChildProfiles { get; set; }
    public DbSet<Caregiver> Caregivers { get; set; }
    public DbSet<CaregiverFamily> CaregiverFamilies { get; set; }
    // public DbSet<Schedule> Schedules { get; set; }
    public YourVillageContext(DbContextOptions options) : base(options) { }
  }
}