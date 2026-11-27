using Cysharp.Threading.Tasks;
using System;
using System.Threading;

namespace _Project.Develop.Runtime.Infrastructure.ConfigsManagment.Loaders
{
    public interface IConfigsLoader
    {
        UniTask LoadAsync(Action<Type, object> onLoad, CancellationToken cancellationToken);
    }
}
