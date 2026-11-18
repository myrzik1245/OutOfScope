using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Bootstrap
{
    public class BootstrapLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<AppBootstrap>();
        }
    }
}
