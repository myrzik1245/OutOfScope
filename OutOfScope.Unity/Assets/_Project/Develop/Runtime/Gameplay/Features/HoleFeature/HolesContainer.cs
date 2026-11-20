using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.HoleFeature
{
    public class HolesContainer : MonoBehaviour, IHoleContainer
    {
        [SerializeField] private List<Hole> _holes;
        
        public IEnumerable<IHole> Holes => _holes;
    }
}
