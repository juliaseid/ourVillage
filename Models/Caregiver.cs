using System;
using System.Collections.Generic;

namespace YourVillage.Models
{
  public class Caregiver
  {
    public Caregiver()
    {
      this.CaregiverFamilies = new HashSet<Family>();
    }
    public string CaregiverId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public ICollection<Family> CaregiverFamilies { get; set; }
    public List<int> GetFamilyIds()
    {
      List<int> FamilyIds = new List<int> { };
      foreach (Family f in CaregiverFamilies)
      {
        FamilyIds.Add(f.FamilyId);
      }
      return FamilyIds;
    }

  }
}