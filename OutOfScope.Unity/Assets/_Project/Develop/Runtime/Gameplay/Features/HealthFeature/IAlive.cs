using _Project.Develop.Runtime.Utils.Reactive.Variable;

namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public interface IAlive
    {
        IReadOnlyReactiveVariable<bool> IsDead { get; }
    }
}
