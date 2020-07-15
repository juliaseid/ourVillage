using System;
using System.Collections.Generic;

namespace ourVillage.Models
{
  public class Child
  {
    public int ChildId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Nickname { get; set; }
    public int Age { get; set; }
    public string AgeUnit { get; set; }
    public DateTime Birthday { get; set; }
    public ICollection<Schedule> DailySchedules { get; set; }
    public int FamilyId { get; set; }
    public virtual Family Family { get; set; }
  }
}