using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public class AppBootstrap : IStartable
    {
        private readonly SceneNavigation _sceneNavigation;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly LevelsProgressionService _levelsProgressionService;

        public AppBootstrap(
            SceneNavigation sceneNavigation,
            ConfigsProviderService configsProviderService,
            LevelsProgressionService levelsProgressionService)
        {
            _sceneNavigation = sceneNavigation;
            _configsProviderService = configsProviderService;
            _levelsProgressionService = levelsProgressionService;
        }

        public void Start()
        {
            SetupApp();
            
            _configsProviderService.Load();
            
            _levelsProgressionService.Initialize();
            _levelsProgressionService.UnlockLevel(0);
            
            _sceneNavigation.OpenMainMenu(new MainMenuInputArgs());
        }

        private void SetupApp()
        {
        }
    }
}
