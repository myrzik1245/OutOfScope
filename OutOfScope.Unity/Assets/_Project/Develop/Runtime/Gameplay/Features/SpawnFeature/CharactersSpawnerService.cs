using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.Gameplay.Features.BoardFeature;
using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Gameplay.Features.HoleFeature;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Threading;
using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.SpawnFeature
{
    public class CharactersSpawnerService : ICharactersSpawner, IDisposable
    {
        private readonly ConfigsProviderService _configs;
        private readonly IBoardService _boardService;
        private readonly CharactersFactory _charactersFactory;
        private readonly GameplayInputArgs _gameplayInputArgs;
        
        private CancellationTokenSource _spawnProcess;

        public CharactersSpawnerService(
            ConfigsProviderService configs,
            IBoardService boardService,
            CharactersFactory charactersFactory,
            GameplayInputArgs gameplayInputArgs)
        {
            _configs = configs;
            _boardService = boardService;
            _charactersFactory = charactersFactory;
            _gameplayInputArgs = gameplayInputArgs;
        }

        private LevelConfig LevelConfig => _configs.Get<LevelsConfig>().Levels[_gameplayInputArgs.LevelIndex];
        public bool Enabled { get; private set; }

        public void Enable()
        {
            CancelSpawnProcess();
            _spawnProcess = new CancellationTokenSource();
            
            SpawnProcess(_spawnProcess.Token).Forget();

            Enabled = true;
        }

        public void Disable()
        {
            CancelSpawnProcess();

            Enabled = false;
        }

        public void Dispose()
        {
            CancelSpawnProcess();
        }

        private async UniTaskVoid SpawnProcess(CancellationToken cancellationToken)
        {
            while (true)
            {
                await UniTask.Delay(TimeSpan.FromSeconds(LevelConfig.SpawnRate), cancellationToken: cancellationToken);

                if (_boardService.TryGetFreeHole(out IHole hole) == false)
                    continue;

                if (_boardService.CanSetupCharacter(hole))
                {
                    ICharacter character = await _charactersFactory.Create(GetRandomCharacterConfig(), cancellationToken);
                    _boardService.SetupCharacter(hole, character);
                }
            }
        }

        private CharacterConfig GetRandomCharacterConfig()
        {
            IReadOnlyList<CharacterConfig> characters = LevelConfig.Characters;
            int randomIndex = Random.Range(0, characters.Count);

            return characters[randomIndex];
        }
        
        private void CancelSpawnProcess()
        {
            _spawnProcess?.Cancel();
            _spawnProcess?.Dispose();
            _spawnProcess = null;
        }
    }
}
