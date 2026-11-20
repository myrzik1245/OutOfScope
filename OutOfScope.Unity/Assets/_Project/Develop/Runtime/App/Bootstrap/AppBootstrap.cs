using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public class AppBootstrap : IStartable
    {
        private readonly SceneNavigation _sceneNavigation;
        private readonly ConfigsProviderService _configsProviderService;

        public AppBootstrap(SceneNavigation sceneNavigation, ConfigsProviderService configsProviderService)
        {
            _sceneNavigation = sceneNavigation;
            _configsProviderService = configsProviderService;
        }

        public void Start()
        {
            SetupApp();
            
            _configsProviderService.Load();
            
            _sceneNavigation.OpenGameplay(new GameplayInputArgs(0));
        }

        private void SetupApp()
        {
        }
    }
}
