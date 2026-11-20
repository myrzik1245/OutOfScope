using _Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public interface IDiedNotifier
    {
        IReadOnlyReactiveEvent Died { get; }
    }
}
