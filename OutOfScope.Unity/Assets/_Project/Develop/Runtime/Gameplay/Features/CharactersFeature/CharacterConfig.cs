using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    [CreateAssetMenu(menuName = "Configs/Gameplay/CharacterConfig", fileName = "CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public string PrefabPath { get; private set; }
        [field: SerializeField, Min(1)] public int  StartHealth { get; private set; }
        [field: SerializeField, Min(1)] public int MaxHealth { get; private set; }
        [field: SerializeField, Min(0)] public float Lifetime { get; private set; }

        private void OnValidate()
        {
            StartHealth = Mathf.Clamp(StartHealth, 0, MaxHealth);
        }
    }
}
