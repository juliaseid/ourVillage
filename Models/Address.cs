namespace YourVillage.Models
{
  public class Address
  {
    public int AddressId { get; set; }
    public string AddressName { get; set; }
    public string StreetAddress { get; set; }
    public string StreetAddressLine2 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public int Zip { get; set; }

  }
}