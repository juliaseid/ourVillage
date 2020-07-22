using System.Collections.Generic;

namespace YourVillage.Models
{
  public class Family
  {
    public int FamilyId { get; set; }
    public string ProfileName { get; set; }
    public string Parent1FirstName { get; set; }
    public string Parent1LastName { get; set; }
    public string Parent1Phone { get; set; }
    public string Parent1Relationship { get; set; }
    public string Parent2FirstName { get; set; }
    public string Parent2LastName { get; set; }
    public string Parent2Phone { get; set; }
    public string Parent2Relationship { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Child> Children { get; set; }
    public Family(string parent1FirstName, string parent1LastName, string parent1Phone, string parent1Relationship)
    {
      Parent1FirstName = parent1FirstName;
      Parent1LastName = parent1LastName;
      Parent1Phone = parent1Phone;
      Parent1Relationship = parent1Relationship;
    }
    public Family(string parent1FirstName, string parent1LastName, string parent1Phone, string parent1Relationship, string parent2FirstName, string parent2LastName, string parent2Phone, string parent2Relationship)
    {
      Parent1FirstName = parent1FirstName;
      Parent1LastName = parent1LastName;
      Parent1Phone = parent1Phone;
      Parent1Relationship = parent1Relationship;
      Parent2FirstName = parent2FirstName;
      Parent2LastName = parent2LastName;
      Parent2Phone = parent2Phone;
      Parent2Relationship = parent2Relationship;
    }
  }
}

