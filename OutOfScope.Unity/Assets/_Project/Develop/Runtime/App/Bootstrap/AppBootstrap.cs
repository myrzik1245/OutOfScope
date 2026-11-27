using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public class AppBootstrap : IAsyncStartable
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

        public async UniTask StartAsync(CancellationToken cancellationToken)
        {
            SetupApp();
            
            await _configsProviderService.Load(cancellationToken);

            foreach (WalletSlotConfigData walletSlotConfigData in _configsProviderService.Get<WalletStartConfig>().StartSlotData)
                _wallet.Add(walletSlotConfigData.Type, walletSlotConfigData.Amount);
            
            _levelsProgressionService.Initialize();
            _levelsProgressionService.UnlockLevel(0);
            
            _sceneNavigation.OpenMainMenu();
        }

        private void SetupApp()
        {
        }
    }
}
