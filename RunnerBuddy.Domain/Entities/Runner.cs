namespace RunnerBuddy.Domain.Entities;

public class Runner : BaseEntity
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int? Height { get; set; }
    public float? Weight { get; set; }
    public ICollection<Session>? Sessions { get; set; }
}