using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.Gameplay.Features.BoardFeature;
using _Project.Develop.Runtime.Gameplay.Features.PlayerFeature;
using _Project.Develop.Runtime.Gameplay.Features.ScoreFeature;
using _Project.Develop.Runtime.Gameplay.Features.SpawnFeature;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop
{
    public class GameSession : IDisposable
    {
        private readonly IBoardService _boardService;
        private readonly IPlayerService _playerService;
        private readonly ICharacterSpawner _characterSpawner;
        private readonly ConfigsProviderService _configsProviderService;
        private readonly GameplayInputArgs _gameplayInputArgs;
        private readonly ScoreService _scoreService;
        private readonly IInputService _inputService;
        
        private readonly List<IDisposable> _subscriptions = new();
        private readonly Wallet _sessionWallet = new();

        public GameSession(
            IBoardService boardService,
            IPlayerService playerService,
            ICharacterSpawner characterSpawner,
            ConfigsProviderService configsProviderService,
            GameplayInputArgs gameplayInputArgs,
            ScoreService scoreService,
            IInputService inputService)
        {
            _boardService = boardService;
            _playerService = playerService;
            _characterSpawner = characterSpawner;
            _configsProviderService = configsProviderService;
            _gameplayInputArgs = gameplayInputArgs;
            _scoreService = scoreService;
            _inputService = inputService;
        }

        public IReadOnlyWallet SessionWallet => _sessionWallet;
        private LevelConfig LevelConfig => _configsProviderService.Get<LevelsConfig>().Levels[_gameplayInputArgs.LevelIndex];
        
        public void Start()
        {
            _characterSpawner.Enable();
            
            _subscriptions.Add(_boardService.EnemyDied.Subscribe(OnEnemyDied));
            _subscriptions.Add(_boardService.EnemyHided.Subscribe(OnEnemyHided));
            _subscriptions.Add(_inputService.NumPadKeyPressed.Subscribe(OnNumPadKeyPressed));
        }

        public void Stop()
        {
            _characterSpawner.Disable();
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();
        }

        private void OnEnemyDied()
        {
            _sessionWallet.Add(LevelConfig.CurrencyTypeByKill, LevelConfig.CurrencyAmountByKill);
            _scoreService.Add(LevelConfig.ScoreByKill);
        }

        private void OnEnemyHided()
        {
            int enemyDamage = LevelConfig.EnemyDamage;
            
            if (_playerService.CanTakeDamage(enemyDamage))
                _playerService.TakeDamage(enemyDamage);
        }

        private void OnNumPadKeyPressed(int number)
        {
            Debug.Log(number);
            _boardService.TryDamage(number, LevelConfig.PlayerDamage);
        }
        
        private void Cleanup()
        {
            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();
            
            _subscriptions.Clear();
        }
    }
}
