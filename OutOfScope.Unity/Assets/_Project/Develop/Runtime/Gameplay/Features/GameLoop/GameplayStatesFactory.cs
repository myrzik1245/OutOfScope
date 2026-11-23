using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Gameplay.Features.GameLoop.States;
using _Project.Develop.Runtime.Gameplay.Features.PlayerFeature;
using _Project.Develop.Runtime.Gameplay.Features.ScoreFeature;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using _Project.Develop.Runtime.Utils.Conditions;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop
{
    public class GameplayStatesFactory
    {
        private readonly IInputService _inputService;
        private readonly SceneNavigation _sceneNavigation;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private readonly IPlayerService _playerService;
        private readonly ScoreService _scoreService;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly GameSession _gameSession;
        private readonly Wallet _wallet;

        public GameplayStatesFactory(
            IInputService inputService,
            SceneNavigation sceneNavigation,
            GameplayInputArgs gameplayInputArgs,
            IPlayerService playerService,
            ScoreService scoreService,
            ConfigsProviderService configsProviderService,
            GameSession gameSession,
            Wallet wallet)
        {
            _inputService = inputService;
            _sceneNavigation = sceneNavigation;
            _gameplayInputArgs = gameplayInputArgs;
            _playerService = playerService;
            _scoreService = scoreService;
            _configsProviderService = configsProviderService;
            _gameSession = gameSession;
            _wallet = wallet;
        }

        private LevelConfig LevelConfig => _configsProviderService.Get<LevelsConfig>().Levels[_gameplayInputArgs.LevelIndex];
        
        public GameplayStateMachine CreateGameplayStateMachine()
        {
            GameSessionState gameSessionState = new(
                _gameSession);

            LoseState loseState = new(
                _inputService,
                _sceneNavigation,
                _gameplayInputArgs);

            WinState winState = new(
                _inputService,
                _sceneNavigation,
                _wallet,
                _gameSession);
            
            ICondition gameProcessToLose = new CompositeCondition(
                new FuncCondition(() => _playerService.IsDead.Value));

            ICondition gameProcessToWin = new CompositeCondition(
                new FuncCondition(() => _scoreService.Score.Value >= LevelConfig.ScoreToWin));
            
            GameplayStateMachine root = new();

            root
                .AddState(gameSessionState)
                .AddState(loseState)
                .AddState(winState);

            root
                .AddTransition(gameSessionState, loseState, gameProcessToLose)
                .AddTransition(gameSessionState, winState, gameProcessToWin);
            
            return root;
        }
    }
}
