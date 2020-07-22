using System.Collections.Generic;

namespace YourVillage.Models
{
  public class Note
  {
    public Note()
    {
      this.Children = new List<ChildNote>();
    }

    public int NoteId { get; set; }
    public string Text { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual ICollection<ChildNote> Children { get; set; }
  }
}