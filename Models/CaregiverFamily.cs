namespace YourVillage.Models
{
  public class CaregiverFamily
  {
    public int CaregiverFamilyId { get; set; }
    public string CaregiverId { get; set; }
    public int FamilyId { get; set; }
    public Caregiver Caregiver { get; set; }
    public Family Family { get; set; }
  }
}