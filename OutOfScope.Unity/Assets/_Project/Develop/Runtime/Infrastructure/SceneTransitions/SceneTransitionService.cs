using _Project.Develop.Runtime.Infrastructure.SceneManagment;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;

namespace _Project.Develop.Runtime.Infrastructure.SceneTransitions
{
    public class SceneTransitionService
    {
        private readonly ScenesService _scenesService;
        
        private bool _isRunning;

        public SceneTransitionService(ScenesService scenesService)
        {
            _scenesService = scenesService;
        }

        public async UniTask SwitchToAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            ISceneInputArgs args = null)
        {
            if (_isRunning)
            {
                Debug.LogWarning($"Transition is already running, switching to scene {sceneKey} ignored");
                return;
            }
            
            _isRunning = true;

            try
            {
                await _scenesService.SwitchToAsync(sceneKey, cancellationToken, args);
            }
            finally
            {
                _isRunning = false;
            }
        }
    }
}
