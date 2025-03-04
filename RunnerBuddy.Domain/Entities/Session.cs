namespace RunnerBuddy.Domain.Entities;

public class Session : BaseEntity
{
    public float Distance { get; set; }
    public float Duration { get; set; }
    public float MediumTempo { get; set; }
    public int Kcal { get; set; }
    public string? Comment { get; set; }
    public int RunnerId { get; set; }
}