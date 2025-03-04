namespace RunnerBuddy.Domain.Entities;

public class Runner : BaseEntity
{
    public string Name { get; set; } = default!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? Age { get; set; }
    public float? Weight { get; set; }
    public float? Height { get; set; }
    public string? Image { get; set; }
    public ICollection<Session> Sessions { get; set; } = new List<Session>();
}