using _Project.Develop.Runtime.Infrastructure.ConfigsManagment.Loaders;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;

namespace _Project.Develop.Runtime.Infrastructure.ConfigsManagment
{
    public class ConfigsProviderService
    {
        private readonly Dictionary<Type, object> _configs = new();
        private readonly IEnumerable<IConfigsLoader> _loaders;

        public ConfigsProviderService(IEnumerable<IConfigsLoader> loaders)
        {
            _loaders = loaders;
        }

        public async UniTask Load(CancellationToken cancellationToken)
        {
            List<UniTask> tasks = new();
            
            foreach (IConfigsLoader loader in _loaders)
                tasks.Add(loader.LoadAsync(AddConfig, cancellationToken));
            
            await UniTask.WhenAll(tasks);
        }

        public T Get<T>() where T : class
        {
            if (_configs.TryGetValue(typeof(T), out object config) == false)
                throw new InvalidOperationException($"Config {typeof(T)} doesn't exist");
            
            return (T)config;
        }
        
        private void AddConfig(Type type, object config)
        {
            if (_configs.TryAdd(type, config) == false)
                throw new InvalidOperationException($"Config already exists for {type.Name}");
        }
    }
}
