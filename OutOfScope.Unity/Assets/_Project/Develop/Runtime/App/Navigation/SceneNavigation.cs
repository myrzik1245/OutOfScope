using _Project.Develop.Runtime.Infrastructure._Project.Develop.Runtime.Infrastructure.SceneManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation
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
        
        public void OpenMainMenu()
        {
            _sceneLoader.Load(Config.MainMenuSceneName);
        }
        
        public void OpenGameplay()
        {
            _sceneLoader.Load(Config.GameplaySceneName);
        }
    }
}
