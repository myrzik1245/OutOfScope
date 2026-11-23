using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot
{
    public class WalletSlot : IReadOnlyWalletSlot
    {
        private ReactiveVariable<int> _amount = new();
        
        public CurrencyType CurrencyType { get; }
        public IReadOnlyReactiveVariable<int> Amount => _amount;

        public WalletSlot(CurrencyType currencyType)
        {
            CurrencyType = currencyType;
        }

        public bool Enough(int amount)
        {
            return _amount.Value - amount >= 0;
        }

        public void Spend(int amount)
        {
            if (Enough(amount) == false)
                throw new InvalidOperationException();
            
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _amount.Value -= amount;
        }

        public void Add(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            
            _amount.Value += amount;
        }
    }
}
