using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Gameplay.Features.PlayerFeature
{
    public class PlayerService : IPlayerService, IInitializable
    {
        private readonly ConfigsProviderService _configsProvider;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private Health _health;

        public PlayerService(
            ConfigsProviderService configsProvider,
            GameplayInputArgs gameplayInputArgs)
        {
            _configsProvider = configsProvider;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public IReadOnlyReactiveVariable<int> CurrentHealth => _health.CurrentHealth;
        public IReadOnlyReactiveVariable<int> MaxHealth => _health.MaxHealth;
        public IReadOnlyReactiveVariable<bool> IsDead => _health.IsDead;
        public IReadOnlyReactiveEvent Died => _health.Died;

        private LevelConfig LevelConfig => _configsProvider.Get<LevelsConfig>().Levels[_gameplayInputArgs.LevelIndex];

        public void Initialize()
        {
            _health = new Health(LevelConfig.PlayerHealth, LevelConfig.PlayerMaxHealth);
        }
        
        public bool CanTakeDamage(int damage)
        {
            return _health.CanTakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}
