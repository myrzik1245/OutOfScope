using _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature
{
    public class Wallet : IReadOnlyWallet
    {
        private List<WalletSlot> _slots = new();
        public IReadOnlyList<IReadOnlyWalletSlot> Slots => _slots;

        public Wallet()
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
                _slots.Add(new WalletSlot(currencyType));
        }
        
        public bool Enough(CurrencyType currencyType, int amount)
        {
            WalletSlot slot = GetSlot(currencyType);
                
            return slot.Enough(amount);
        }

        public void Spend(CurrencyType currencyType, int amount)
        {
            if (Enough(currencyType, amount) == false)
                throw new InvalidOperationException();

            WalletSlot slot = GetSlot(currencyType);

            slot.Spend(amount);
        }

        public void Add(CurrencyType currencyType, int amount)
        {
            if (amount < 0)
                throw new InvalidOperationException();

            WalletSlot slot = GetSlot(currencyType);

            slot.Add(amount);
        }

        private WalletSlot GetSlot(CurrencyType currencyType)
        {
            return _slots.First(s => s.CurrencyType == currencyType);
        }
    }
}
