using _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure._Project.Develop.Runtime.Infrastructure.SceneManagment;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Root
{
    public class RootLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<ISceneLoader, SimpleSceneLoader>(Lifetime.Singleton);
            builder.Register<SceneNavigation>(Lifetime.Singleton);
        }
    }
}
