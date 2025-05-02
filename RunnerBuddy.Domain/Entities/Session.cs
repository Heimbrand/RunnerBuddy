namespace RunnerBuddy.Domain.Entities;

public class Session : BaseEntity
{
    public string? Location { get; set; }
    public float? Distance { get; set; }
    public DateTime? Date { get; set; }
    public string? Notes { get; set; }
    public int RunnerId { get; set; }
}