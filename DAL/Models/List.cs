namespace DAL.Models;

public partial class List
{
    public int ListId { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Note> Notes { get; } = new List<Note>();
}
