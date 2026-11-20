using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.SceneManagment;
using UnityEngine;

namespace _Project.Develop.Runtime.App.Navigation
{
    public class SceneNavigation
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly ConfigsProviderService _configsProviderService;

        public SceneNavigation(ISceneLoader sceneLoader, ConfigsProviderService configsProviderService)
        {
            _sceneLoader = sceneLoader;
            _configsProviderService = configsProviderService;
        }

        private SceneNavigationConfig Config => _configsProviderService.Get<SceneNavigationConfig>();
        
        public void OpenMainMenu(MainMenuInputArgs args)
        {
            _sceneLoader.Load(Config.MainMenuSceneName, args);
        }
        
        public void OpenGameplay(GameplayInputArgs args)
        {
            _sceneLoader.Load(Config.GameplaySceneName, args);
        }
    }
}
