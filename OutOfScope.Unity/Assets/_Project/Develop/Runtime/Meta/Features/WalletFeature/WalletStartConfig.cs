using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature
{
    [CreateAssetMenu(menuName = "Configs/Meta/WalletStartConfig", fileName = "WalletStartConfig", order = 0)]
    public class WalletStartConfig : ScriptableObject
    {
        [SerializeField] private List<WalletSlotConfigData> _startSlotData = new();
        
        public IReadOnlyList<WalletSlotConfigData> StartSlotData => _startSlotData;
    }
}
