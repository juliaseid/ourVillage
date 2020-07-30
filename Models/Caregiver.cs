using System;
using System.Collections.Generic;

namespace YourVillage.Models
{
  public class Caregiver
  {
    public Caregiver()
    {
      this.Families = new HashSet<CaregiverFamily>();
    }
    public string CaregiverId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Phone { get; set; }
    public bool Evenings { get; set; }
    public bool Weekends { get; set; }
    public bool Weekdays { get; set; }
    public bool Emergency { get; set; }
    public virtual ICollection<CaregiverFamily> Families { get; set; }
    public List<int> GetFamilyIds()
    {
      List<int> FamilyIds = new List<int> { };
      foreach (CaregiverFamily f in Families)
      {
        FamilyIds.Add(f.FamilyId);
      }
      return FamilyIds;
    }

  }
}