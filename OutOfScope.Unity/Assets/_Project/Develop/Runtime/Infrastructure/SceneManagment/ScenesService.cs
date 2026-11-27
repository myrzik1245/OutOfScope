using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public class ScenesService : IInitializable
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly string _bufferSceneKey;
        
        private readonly List<LoadedScene> _loadedScenes = new();

        public ScenesService(ISceneLoader sceneLoader, string bufferSceneKey)
        {
            _sceneLoader = sceneLoader;
            _bufferSceneKey = bufferSceneKey;
        }

        public void Initialize()
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                
                _loadedScenes.Add(new LoadedScene(scene.name, scene));
            }
        }

        public async UniTask<Scene> SwitchToAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            ISceneInputArgs args = null,
            IProgress<float> progress = null)
        {
            await LoadAsync(_bufferSceneKey, cancellationToken);

            cancellationToken.ThrowIfCancellationRequested();
            
            return await LoadAsync(sceneKey, cancellationToken, args, progress);
        }

        public async UniTask<Scene> LoadAdditiveAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            ISceneInputArgs args = null,
            IProgress<float> progress = null)
        {
            int index = IndexOf(sceneKey);

            if (index != -1)
            {
                Debug.LogWarning($"Scene {sceneKey} is already loaded");
                return _loadedScenes[index].Scene;
            }
            
            Scene scene = await _sceneLoader.LoadAsync(sceneKey, cancellationToken, ExtraRegistrations(args), progress);
            
            _loadedScenes.Add(new LoadedScene(sceneKey, scene));
            
            return scene;
        }

        public async UniTask UnloadAsync(string sceneKey)
        {
            int index = IndexOf(sceneKey);

            if (index == -1)
                return;
            
            _loadedScenes.RemoveAt(index);
            await _sceneLoader.UnloadAsync(sceneKey);
        }
        
        private async UniTask<Scene> LoadAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            ISceneInputArgs args = null,
            IProgress<float> progress = null)
        {
            Action<IContainerBuilder> extraRegistrations = ExtraRegistrations(args);
            
            Scene scene = await _sceneLoader.LoadAsync(sceneKey, cancellationToken, extraRegistrations, progress);
            
            _loadedScenes.Add(new LoadedScene(sceneKey, scene));
            
            SceneManager.SetActiveScene(scene);

            for (int i = _loadedScenes.Count - 1; i >= 0; i--)
            {
                if (_loadedScenes[i].Key == sceneKey)
                    continue;

                string unloadKey = _loadedScenes[i].Key;
                _loadedScenes.RemoveAt(i);
                await _sceneLoader.UnloadAsync(unloadKey);
            }
            
            return scene;
        }
        
        private int IndexOf(string sceneKey)
        {
            for (int i = 0; i < _loadedScenes.Count; i++)
                if (_loadedScenes[i].Key == sceneKey)
                    return i;
            
            return -1;
        }
        
        private Action<IContainerBuilder> ExtraRegistrations(ISceneInputArgs args)
        {
            if (args == null)
                return null;

            return builder => builder.RegisterInstance(args).As(args.GetType());
        }
        
        private readonly struct LoadedScene
        {
            public readonly string Key;
            public readonly Scene Scene;

            public LoadedScene(string key, Scene scene)
            {
                Key = key;
                Scene = scene;
            }
        }
    }
}
