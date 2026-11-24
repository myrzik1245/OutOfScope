using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public class AppBootstrap : IStartable
    {
        private readonly SceneNavigation _sceneNavigation;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly Wallet _wallet;

        public AppBootstrap(
            SceneNavigation sceneNavigation,
            ConfigsProviderService configsProviderService,
            LevelsProgressionService levelsProgressionService,
            Wallet wallet)
        {
            _sceneNavigation = sceneNavigation;
            _configsProviderService = configsProviderService;
            _levelsProgressionService = levelsProgressionService;
            _wallet = wallet;
        }

        public void Start()
        {
            SetupApp();
            
            _configsProviderService.Load();

            foreach (WalletSlotConfigData walletSlotConfigData in _configsProviderService.Get<WalletStartConfig>().StartSlotData)
                _wallet.Add(walletSlotConfigData.Type, walletSlotConfigData.Amount);
            
            _levelsProgressionService.Initialize();
            _levelsProgressionService.UnlockLevel(0);
            
            _sceneNavigation.OpenMainMenu(new MainMenuInputArgs());
        }

        private void SetupApp()
        {
        }
    }
}
