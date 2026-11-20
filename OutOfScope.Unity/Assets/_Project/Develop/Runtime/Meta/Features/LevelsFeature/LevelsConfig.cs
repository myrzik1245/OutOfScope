using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.LevelsFeature
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/LevelsConfig", fileName = "LevelsConfig", order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private List<LevelConfig> _levels;
        
        public IReadOnlyList<LevelConfig> Levels => _levels;
    }
}
