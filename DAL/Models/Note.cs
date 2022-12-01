namespace DAL.Models;

public partial class Note
{
    public int NoteId { get; set; }

    public int ListId { get; set; }

    public string Title { get; set; } = null!;

    public decimal? NoteValue { get; set; }

    public string? NoteUnitType { get; set; }

    public bool IsDone { get; set; }
}
