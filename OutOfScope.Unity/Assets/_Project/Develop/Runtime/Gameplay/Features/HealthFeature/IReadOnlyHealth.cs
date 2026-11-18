using _Project.Develop.Runtime.Utils.Reactive.Variable;

namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public interface IReadOnlyHealth
    {
        IReadOnlyReactiveVariable<int> CurrentHealth { get; }
        IReadOnlyReactiveVariable<int> MaxHealth { get; }
    }
}
