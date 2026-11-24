using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Meta.Features.SelectLevelFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.MainMenu
{
    public class MainMenuLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<MainMenuBootstrap>();

            builder.Register<WalletLogger>(Lifetime.Singleton);
            builder.Register<LevelsLogger>(Lifetime.Singleton);
            
            builder.Register<LevelSelectorService>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
        }
    }
}
