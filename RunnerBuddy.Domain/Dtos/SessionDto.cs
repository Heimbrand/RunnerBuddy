namespace RunnerBuddy.Domain.Dtos;

public class SessionDto : BaseDto
{
    public string? Location { get; set; }
    public float? PlannedDistance { get; set; }
    public float? ActualDistance { get; set; }
    public string? AveragePace { get; set; } // Example: "5:30 min/km"
    public DateTime? Date { get; set; }
    public bool IsCompleted { get; set; }
    public string? Notes { get; set; }
    public int RunnerId { get; set; }
}