using _Project.Develop.Runtime.Utils.AssetsManagment;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils.ConfigsManagment.Loaders
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

        public void Load(Action<Type, object> onLoad)
        {
            foreach (KeyValuePair<Type, string> configPath in _configPaths)
            {
                ScriptableObject config = _assetsLoader.Load<ScriptableObject>(configPath.Value);
                
                if (config == null)
                    throw new InvalidOperationException($"Config {configPath.Key} not found");

                onLoad(configPath.Key, config);
            }
        }
    }
}
