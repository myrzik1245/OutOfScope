using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature
{
    [Serializable]
    public class WalletSlotConfigData
    {
        [field: SerializeField] public CurrencyType Type { get; private set; }
        [field: SerializeField] public int Amount { get; private set; }
    }
}
