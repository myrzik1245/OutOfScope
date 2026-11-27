using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.SceneManagment;
using _Project.Develop.Runtime.Infrastructure.SceneTransitions;
using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace _Project.Develop.Runtime.App.Navigation
{
    public class SceneNavigation
    {
        private readonly SceneTransitionService _sceneTransitionService;
        private readonly ConfigsProviderService _configsProviderService;
        
        private CancellationToken CancellationToken => Application.exitCancellationToken;

        public SceneNavigation(SceneTransitionService sceneTransitionService, ConfigsProviderService configsProviderService)
        {
            _sceneTransitionService = sceneTransitionService;
            _configsProviderService = configsProviderService;
        }

        private SceneNavigationConfig Config => _configsProviderService.Get<SceneNavigationConfig>();
        
        public void OpenMainMenu()
        {
            MainMenuInputArgs args = new();
            
            _sceneTransitionService.SwitchToAsync(
                Config.MainMenuSceneName,
                CancellationToken,
                args).Forget();
        }
        
        public void OpenGameplay(int levelNumber)
        {
            GameplayInputArgs args = new(levelNumber);
            
            _sceneTransitionService.SwitchToAsync(
                Config.GameplaySceneName,
                CancellationToken,
                args).Forget();
        }
    }
}
