using _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure._Project.Develop.Runtime.Infrastructure.SceneManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.AssetsManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment;
using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ConfigsManagment.Loaders;
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
            builder.Register<SceneNavigation>(Lifetime.Singleton);
            
            builder.Register<ISceneLoader, SimpleSceneLoader>(Lifetime.Singleton);
            builder.Register<IAssetsLoader, ResourcesAssetsLoader>(Lifetime.Singleton);
            
            builder.Register<IConfigsLoader, AssetsConfigsLoader>(Lifetime.Singleton)
                .WithParameter("configPaths", new Dictionary<Type, string>
                {
                    { typeof(SceneNavigationConfig), "Configs/Core/SceneNavigationConfig" },
                });
            builder.Register<ConfigsProviderService>(Lifetime.Singleton);
        }
    }
}
