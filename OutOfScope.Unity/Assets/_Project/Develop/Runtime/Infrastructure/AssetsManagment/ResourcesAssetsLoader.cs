using Cysharp.Threading.Tasks;
using System;
using System.IO;
using System.Threading;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Infrastructure.AssetsManagment
{
    public class ResourcesAssetsLoader : IAssetsLoader
    {
        public async UniTask<T> LoadAsync<T>(string path, CancellationToken cancellationToken, IProgress<float> progress = null) where T : Object
        {
            Object asset = await Resources.LoadAsync<T>(path).ToUniTask(cancellationToken: cancellationToken, progress: progress);
            
            if (asset == null)
                throw new FileNotFoundException($"Could not load asset: {path}" );
            
            return asset as T;
        }
    }
}
