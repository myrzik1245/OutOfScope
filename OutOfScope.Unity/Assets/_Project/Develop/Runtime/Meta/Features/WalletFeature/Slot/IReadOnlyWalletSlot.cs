using _Project.Develop.Runtime.Utils.Reactive.Variable;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot
{
    public interface IReadOnlyWalletSlot
    {
        public CurrencyType CurrencyType { get; }
        public IReadOnlyReactiveVariable<int> Amount { get; }
    }
}
