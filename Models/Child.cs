using System;
using System.Collections.Generic;

namespace YourVillage.Models
{
  public class Child
  {
    public Child()
    {
      this.Notes = new List<ChildNote>();
    }
    public int ChildId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public int Age { get; set; }
    public string AgeUnit { get; set; }
    public DateTime Birthday { get; set; }
    public ChildProfile Profile { get; set; }
    // public ICollection<Schedule> DailySchedules { get; set; }
    public ICollection<ChildNote> Notes { get; set; }
    public int FamilyId { get; set; }
    public Family Family { get; set; }
  }
}