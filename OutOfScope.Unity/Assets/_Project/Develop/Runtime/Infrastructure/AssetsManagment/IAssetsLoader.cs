using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Infrastructure.AssetsManagment
{
    public interface IAssetsLoader
    {
        public UniTask<T> LoadAsync<T>(string path, CancellationToken cancellationToken, IProgress<float> progress = null) where T : Object;
    }
}
