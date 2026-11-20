using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Gameplay.Features.BoardFeature
{
    public interface IReadOnlyBoardService
    {
        IReadOnlyReactiveEvent CharacterHided  { get; }
        IReadOnlyReactiveEvent<ICharacter> CharacterDied { get; }
    }
}
