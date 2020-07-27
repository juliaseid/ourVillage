using System;
using System.Collections.Generic;

namespace YourVillage.Models
{
  public class ChildProfile
  {
    public int ChildProfileId { get; set; }
    public Child child { get; set; }
    public string MedicalConditions { get; set; }
    public string Medications { get; set; }
    public string Allergies { get; set; }
    public string Dietary { get; set; }
    public string Snacks { get; set; }
    public string Meals { get; set; }
    public string Bedtime { get; set; }
    public string Naptime { get; set; }
    public string Behavior { get; set; }
    public string Rewards { get; set; }
    public string Consequences { get; set; }
    public string PackForSchool { get; set; }
    public string SchoolMeals { get; set; }
    public string SchoolDetails { get; set; }
    public string Homework { get; set; }

  }
}