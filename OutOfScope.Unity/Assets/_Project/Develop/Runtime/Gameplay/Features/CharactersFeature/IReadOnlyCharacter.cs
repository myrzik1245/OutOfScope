using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public interface IReadOnlyCharacter : IReadOnlyHealth, IAlive, IReadOnlyShowable, IReadOnlyHidable, IDiedNotifier
    {
    }
}
