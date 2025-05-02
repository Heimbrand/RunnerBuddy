namespace RunnerBuddy.Domain.Dtos;

public class RunnerDto : BaseDto
{
    public string? Name { get; set; }
    public int? Age { get; set; }
    public int? Height { get; set; }
    public float? Weight { get; set; }
    public List<SessionDto>? Sessions { get; set; }
}