using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment.Loaders;
using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment
{
    public class ConfigsProviderService
    {
        private readonly Dictionary<Type, object> _configs = new();
        private readonly IEnumerable<IConfigsLoader> _loaders;

        public ConfigsProviderService(IEnumerable<IConfigsLoader> loaders)
        {
            _loaders = loaders;
        }

        public void Load()
        {
            foreach (IConfigsLoader loader in _loaders)
                loader.Load(AddConfig);
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
