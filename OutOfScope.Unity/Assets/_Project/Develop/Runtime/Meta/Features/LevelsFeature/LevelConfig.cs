using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.LevelsFeature
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/Levels/LevelConfig", fileName = "LevelConfig", order = 0)]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public float SpawnRate { get; private set; }
        [field: SerializeField] public int PlayerHealth { get; private set; }
        [field: SerializeField] public int PlayerMaxHealth { get; private set; }
        [field: SerializeField] public int EnemyDamage { get; private set; }
        [field: SerializeField] public int PlayerDamage { get; private set; }
        [field: SerializeField] public int ScoreByKill { get; private set; }
        [field: SerializeField] public int ScoreToWin { get; private set; }
        [field: SerializeField] public CurrencyType CurrencyTypeByKill { get; private set; }
        [field: SerializeField] public int CurrencyAmountByKill { get; private set; }
        [SerializeField] private List<CharacterConfig> _characters;
        
        public IReadOnlyList<CharacterConfig> Characters => _characters;

        private void OnValidate()
        {
            PlayerHealth = Mathf.Clamp(PlayerHealth, 0, PlayerMaxHealth);
        }
    }
}
