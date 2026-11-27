using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.AssetsManagment;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment.Loaders;
using _Project.Develop.Runtime.Infrastructure.CoroutineManagment;
using _Project.Develop.Runtime.Infrastructure.InputService.Keyboard;
using _Project.Develop.Runtime.Infrastructure.ProcessManagment;
using _Project.Develop.Runtime.Infrastructure.SceneManagment;
using _Project.Develop.Runtime.Infrastructure.SceneTransitions;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Root
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfigsLoaders(builder);
            
            builder.Register<SceneNavigation>(Lifetime.Singleton);
            builder.Register<SceneTransitionService>(Lifetime.Singleton);
            builder.Register<ProcessFactory>(Lifetime.Singleton);
            builder.Register<ConfigsProviderService>(Lifetime.Singleton);
            builder.Register<LevelsProgressionService>(Lifetime.Singleton);
            
            builder.Register<ISceneLoader, SceneLoader>(Lifetime.Singleton);
            builder.Register<IAssetsLoader, ResourcesAssetsLoader>(Lifetime.Singleton);
            
            builder.Register<KeyboardInput>(Lifetime.Singleton).AsImplementedInterfaces();
            
            builder.Register<Wallet>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            
            builder.Register<ScenesService>(Lifetime.Singleton)
                .WithParameter("bufferSceneKey", "Empty").AsImplementedInterfaces().AsSelf();

            builder.RegisterComponentOnNewGameObject<CoroutinePerformer>(Lifetime.Singleton).As<ICoroutinePerformer>();
        }

        private void RegisterConfigsLoaders(IContainerBuilder builder)
        {
            builder.Register<IConfigsLoader, AssetsConfigsLoader>(Lifetime.Singleton)
                .WithParameter("configPaths", new Dictionary<Type, string>
                {
                    { typeof(SceneNavigationConfig), "Configs/Core/SceneNavigationConfig" },
                    { typeof(LevelsConfig), "Configs/Meta/LevelsConfig" },
                    { typeof(WalletStartConfig), "Configs/Meta/WalletStartConfig" },
                });
        }
    }
}
