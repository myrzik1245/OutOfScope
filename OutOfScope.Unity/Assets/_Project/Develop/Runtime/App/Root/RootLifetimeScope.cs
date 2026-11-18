using _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure._Project.Develop.Runtime.Infrastructure.SceneManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.AssetsManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment.Loaders;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.CoroutineManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ProcessManagment;
using System;
using System.Collections.Generic;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Root
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            RegisterConfigsLoaders(builder);
            
            builder.Register<SceneNavigation>(Lifetime.Singleton);
            builder.Register<ProcessFactory>(Lifetime.Singleton);
            builder.Register<ConfigsProviderService>(Lifetime.Singleton);
            
            builder.Register<ISceneLoader, SimpleSceneLoader>(Lifetime.Singleton);
            builder.Register<IAssetsLoader, ResourcesAssetsLoader>(Lifetime.Singleton);

            builder.RegisterComponentOnNewGameObject<CoroutinePerformer>(Lifetime.Singleton).As<ICoroutinePerformer>();
        }

        private void RegisterConfigsLoaders(IContainerBuilder builder)
        {
            builder.Register<IConfigsLoader, AssetsConfigsLoader>(Lifetime.Singleton)
                .WithParameter("configPaths", new Dictionary<Type, string>
                {
                    { typeof(SceneNavigationConfig), "Configs/Core/SceneNavigationConfig" },
                });
        }
    }
}
