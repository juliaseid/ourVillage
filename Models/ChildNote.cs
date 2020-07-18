namespace ourVillage.Models
{
  public class ChildNote
  {
    public int ChildNoteId { get; set; }
    public int ChildId { get; set; }
    public int NoteId { get; set; }
    public Child Child { get; set; }
    public Note Note { get; set; }
  }
}