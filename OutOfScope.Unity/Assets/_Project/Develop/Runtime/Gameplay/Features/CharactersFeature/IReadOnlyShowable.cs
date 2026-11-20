using _Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public interface IReadOnlyShowable
    {
        IReadOnlyReactiveEvent Showed { get; }
    }
}
