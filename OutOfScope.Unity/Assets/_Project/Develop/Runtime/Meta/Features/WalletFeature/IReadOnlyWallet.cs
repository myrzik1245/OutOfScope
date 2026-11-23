using _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Meta.Features.WalletFeature
{
    public interface IReadOnlyWallet
    {
        IReadOnlyList<IReadOnlyWalletSlot> Slots { get; }
    }
}
