using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.HoleFeature
{
    public interface IHole : IReadOnlyHole
    {
        bool CanSetupCharacter();
        void SetupCharacter(ICharacter character);
        bool TryDamage(int damage);
    }
}
