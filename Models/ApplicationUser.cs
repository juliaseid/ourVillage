using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YourVillage.Models
{
  public class ApplicationUser : IdentityUser
  {
    // [Key]
    // [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
    // public int ParentId { get; set; }
    public virtual Family Family { get; set; }
    public int FamilyId { get; set; }
  }
}


