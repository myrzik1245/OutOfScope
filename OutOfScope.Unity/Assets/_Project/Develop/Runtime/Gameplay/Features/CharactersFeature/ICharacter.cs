using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public interface ICharacter : IReadOnlyCharacter, IDamageable, IKillable, ISetupable, IShowable
    {
    }
}
