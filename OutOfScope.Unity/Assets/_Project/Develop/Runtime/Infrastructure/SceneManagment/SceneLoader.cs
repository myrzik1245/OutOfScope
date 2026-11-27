using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public class SceneLoader : ISceneLoader, IDisposable
    {
        private IDisposable _registrations;
        
        public async UniTask<Scene> LoadAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            Action<IContainerBuilder> extraRegistrations = null,
            IProgress<float> progress = null)
        {
            if (extraRegistrations != null)
                _registrations = LifetimeScope.Enqueue(extraRegistrations);
            
            try
            {
                await SceneManager.LoadSceneAsync(sceneKey, LoadSceneMode.Additive).ToUniTask(cancellationToken: cancellationToken, progress: progress);
                
                return SceneManager.GetSceneByName(sceneKey);
            }
            finally
            {
                CloseRegistrations();
            }
        }

        public UniTask UnloadAsync(string sceneKey)
        {
            return SceneManager.UnloadSceneAsync(sceneKey).ToUniTask();
        }
        
        public void Dispose()
        {
            CloseRegistrations();
        }
        
        private void CloseRegistrations()
        {
            _registrations?.Dispose();
            _registrations = null;
        }
    }
}
