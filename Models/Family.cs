using System.Collections.Generic;

namespace ourVillage.Models
{
  public class Family
  {
    public int FamilyId { get; set; }
    //require Parent1 info, allow up to 4 parents thru overloaded constructor
    public string Parent1FirstName { get; set; }
    public string Parent1LastName { get; set; }
    public string Parent1Phone { get; set; }
    public string Parent1Relationship { get; set; }
    public string Parent1AddressLine1 { get; set; }
    public string Parent1AddressLine2 { get; set; }
    public int Parent1ZipCode { get; set; }
    public virtual ICollection<Contact> Contacts { get; set; }
    public virtual ICollection<Address> Addresses { get; set; }
    public virtual ICollection<Child> Children { get; set; }
  }
}

//this should be an overloaded constructor to allow up to 4 parents