using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.LevelsFeature
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/LevelConfig", fileName = "LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRate { get; private set; }
        [SerializeField] private List<CharacterConfig> _characters;
        
        public IReadOnlyList<CharacterConfig> Characters => _characters;
    }
}
