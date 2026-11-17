using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayBootstrap>();
        }
    }
}
