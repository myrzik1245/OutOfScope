using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public interface IReadOnlyHidable
    {
        IReadOnlyReactiveEvent Hided { get; }
        IReadOnlyReactiveVariable<float> HideProcessProgress { get; }
    }
}
