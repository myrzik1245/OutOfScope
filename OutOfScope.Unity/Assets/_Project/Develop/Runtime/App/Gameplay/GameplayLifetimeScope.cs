using _Project.Develop.Runtime.Gameplay.Features.BoardFeature;
using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Gameplay.Features.HoleFeature;
using _Project.Develop.Runtime.Gameplay.Features.SpawnFeature;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    public class GameplayLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameplayBootstrap>();
            builder.RegisterComponentInHierarchy<HolesContainer>().As<IHoleContainer>();
            builder.Register<CharactersFactory>(Lifetime.Singleton).AsImplementedInterfaces().AsSelf();
            builder.Register<BoardService>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CharactersSpawnerService>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
