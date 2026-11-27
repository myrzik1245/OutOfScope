using _Project.Develop.Runtime.Infrastructure.AssetsManagment;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.ConfigsManagment.Loaders
{
    public class AssetsConfigsLoader : IConfigsLoader
    {
        private readonly IAssetsLoader _assetsLoader;
        private readonly IReadOnlyDictionary<Type, string> _configPaths;

        public AssetsConfigsLoader(IAssetsLoader assetsLoader, IReadOnlyDictionary<Type, string> configPaths)
        {
            _assetsLoader = assetsLoader;
            _configPaths = configPaths;
        }

        public async UniTask LoadAsync(Action<Type, object> onLoad, CancellationToken cancellationToken)
        {
            List<UniTask> tasks = new();
            
            foreach (KeyValuePair<Type, string> configPath in _configPaths)
                tasks.Add(LoadConfigAsync(configPath.Key, configPath.Value, onLoad, cancellationToken));

            await UniTask.WhenAll(tasks);
        }

        private async UniTask LoadConfigAsync(
            Type type,
            string path,
            Action<Type, object> onLoad,
            CancellationToken cancellationToken)
        {
            ScriptableObject config = await _assetsLoader.LoadAsync<ScriptableObject>(path, cancellationToken);
                
            if (config == null)
                throw new InvalidOperationException($"Config {type} not found with path {path}");
            
            onLoad(type, config);
        }
    }
}
