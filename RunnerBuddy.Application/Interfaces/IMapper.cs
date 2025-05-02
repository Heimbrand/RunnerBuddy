namespace RunnerBuddy.Application.Interfaces;

public interface IMapper<Tentity, TDto> where Tentity : class where TDto : class
{
    public Tentity MapToEntity(TDto dto);
    public TDto MapToDto(Tentity entity);
}