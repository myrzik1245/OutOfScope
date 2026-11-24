using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    public class MainMenuBootstrap : IStartable
    {
        private readonly WalletLogger _walletLogger;
        private readonly LevelsLogger _levelsLogger;

        public MainMenuBootstrap(WalletLogger walletLogger, LevelsLogger levelsLogger)
        {
            _walletLogger = walletLogger;
            _levelsLogger = levelsLogger;
        }

        public void Start()
        {
            _walletLogger.Show();
            _levelsLogger.Show();
        }
    }
}
