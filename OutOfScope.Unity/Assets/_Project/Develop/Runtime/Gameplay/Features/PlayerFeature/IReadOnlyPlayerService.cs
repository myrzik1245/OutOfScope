using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerFeature
{
    public interface IReadOnlyPlayerService : IReadOnlyHealth, IAlive, IDiedNotifier
    {
    }
}
