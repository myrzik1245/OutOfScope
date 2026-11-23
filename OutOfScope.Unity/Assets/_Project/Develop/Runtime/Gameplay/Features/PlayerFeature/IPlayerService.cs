using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerFeature
{
    public interface IPlayerService : IReadOnlyPlayerService, IDamageable
    {
    }
}
