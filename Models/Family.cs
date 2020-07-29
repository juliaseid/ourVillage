using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace YourVillage.Models
{
  public class Family
  {
    public Family()
    {
      Random random = new Random();
      this.Caregivers = new HashSet<CaregiverFamily>();
      this.SecretCode = random.Next(100000, 999999);
      this.CaregiverIds = String.Join(",", GetCaregiverIds());
    }
    public int FamilyId { get; set; }
    public string ParentId { get; set; }
    public int SecretCode { get; set; }
    public ICollection<CaregiverFamily> Caregivers { get; set; }
    // public List<string> CaregiverIds { get; set; }
    public string CaregiverIds { get; set; }
    [Required]
    public string ProfileName { get; set; }
    [Required]
    public string Parent1FirstName { get; set; }
    [Required]
    public string Parent1LastName { get; set; }
    [Required]
    public string Parent1Phone { get; set; }
    [Required]
    public string Parent1Relationship { get; set; }
    public string Parent2FirstName { get; set; }
    public string Parent2LastName { get; set; }
    public string Parent2Phone { get; set; }
    public string Parent2Relationship { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Child> Children { get; set; }
    // public virtual ICollection<ApplicationUser> Caregivers { get; set; }
    public List<string> GetCaregiverIds()
    {
      List<string> CaregiverIds = new List<string> { };
      foreach (CaregiverFamily c in Caregivers)
      {
        CaregiverIds.Add(c.CaregiverId);
      }
      return CaregiverIds;
    }
  }
}

