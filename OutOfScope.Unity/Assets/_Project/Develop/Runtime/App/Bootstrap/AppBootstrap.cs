using _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment;
using VContainer.Unity;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Bootstrap
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
            
            _sceneNavigation.OpenMainMenu();
        }

        private void SetupApp()
        {
        }
    }
}
