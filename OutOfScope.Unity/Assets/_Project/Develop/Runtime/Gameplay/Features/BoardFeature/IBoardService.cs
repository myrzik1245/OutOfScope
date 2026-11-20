using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Gameplay.Features.HoleFeature;

namespace _Project.Develop.Runtime.Gameplay.Features.BoardFeature
{
    public interface IBoardService : IReadOnlyBoardService
    {
        bool TryDamage(int index, int damage);
        bool TryGetFreeHole(out IHole freeHole);
        bool CanSetupCharacter(IHole hole);
        void SetupCharacter(IHole hole, ICharacter character);
    }
}
