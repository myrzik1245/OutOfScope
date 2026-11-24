using _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot;
using System.Text;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature
{
    public class WalletLogger
    {
        private readonly Wallet _wallet;

        public WalletLogger(Wallet wallet)
        {
            _wallet = wallet;
        }

        public void Show()
        {
            StringBuilder builder = new();

            foreach (IReadOnlyWalletSlot walletSlot in _wallet.Slots)
                builder.AppendLine($"Currency {walletSlot.CurrencyType} | Amount {walletSlot.Amount.Value}");
            
            Debug.Log(builder.ToString());
        }
    }
}
