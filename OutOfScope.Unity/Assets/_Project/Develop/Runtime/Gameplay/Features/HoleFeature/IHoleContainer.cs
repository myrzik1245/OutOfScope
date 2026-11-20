using System.Collections.Generic;

namespace _Project.Develop.Runtime.Gameplay.Features.HoleFeature
{
    public interface IHoleContainer
    {
        public IEnumerable<IHole> Holes { get; }
    }
}
