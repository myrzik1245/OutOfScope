using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Gameplay.Features.HoleFeature
{
    public interface IReadOnlyHole
    {
        bool HasCharacter { get; }
        IReadOnlyReactiveEvent CharacterHided { get; }
        IReadOnlyReactiveEvent<ICharacter> CharacterDied { get; }
    }

}
