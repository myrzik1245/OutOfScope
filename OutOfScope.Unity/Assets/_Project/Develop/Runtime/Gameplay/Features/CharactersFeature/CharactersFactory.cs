using _Project.Develop.Runtime.Infrastructure.AssetsManagment;
using _Project.Develop.Runtime.Infrastructure.ProcessManagment;
using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public class CharactersFactory : IDisposable
    {
        private readonly IAssetsLoader _assetsLoader;
        private readonly IObjectResolver _objectResolver;
        private readonly ProcessFactory _processFactory;
        
        private Dictionary<Character, List<IDisposable>> _characterSubscriptions = new();
        
        public CharactersFactory(
            IAssetsLoader assetsLoader,
            IObjectResolver objectResolver,
            ProcessFactory processFactory)
        {
            _assetsLoader = assetsLoader;
            _objectResolver = objectResolver;
            _processFactory = processFactory;
        }

        public ICharacter Create(CharacterConfig config)
        {
            Character prefab = _assetsLoader.Load<Character>(config.PrefabPath);
            Character instance = _objectResolver.Instantiate(prefab);

            IProcess hideProcess = _processFactory.CreateProcess(config.Lifetime);
            
            instance.Initialize(
                hideProcess,
                config.StartHealth,
                config.MaxHealth);
            
            List<IDisposable> subscriptions = new();
            
            subscriptions.Add(instance.Hided.Subscribe(() => Release(instance)));
            subscriptions.Add(instance.Died.Subscribe(() => Release(instance)));
            
            _characterSubscriptions.Add(instance, subscriptions);
            
            return instance;
        }

        public void Dispose()
        {
            foreach (KeyValuePair<Character, List<IDisposable>> characterSubscriptions in _characterSubscriptions)
                ClearCharacterSubscriptions(characterSubscriptions.Value);
            
            _characterSubscriptions.Clear();
        }

        private void Release(Character character)
        {
            if (_characterSubscriptions.TryGetValue(character, out List<IDisposable> subscriptions) == false)
                throw new InvalidOperationException();
            
            ClearCharacterSubscriptions(subscriptions);
            
            _characterSubscriptions.Remove(character);
            
            Object.Destroy(character.gameObject);
        }

        private void ClearCharacterSubscriptions(List<IDisposable> subscriptions)
        {
            foreach (IDisposable subscription in subscriptions)
                subscription.Dispose();
            
            subscriptions.Clear();
        }
    }
}
