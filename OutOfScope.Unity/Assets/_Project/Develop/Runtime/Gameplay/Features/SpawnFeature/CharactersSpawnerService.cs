using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.Gameplay.Features.BoardFeature;
using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Gameplay.Features.HoleFeature;
using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Infrastructure.CoroutineManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.SpawnFeature
{
    public class CharactersSpawnerService : IInitializable, ICharacterSpawner
    {
        private readonly ConfigsProviderService _configs;
        private readonly IBoardService _boardService;
        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly CharactersFactory _charactersFactory;
        private readonly GameplayInputArgs _gameplayInputArgs;

        public CharactersSpawnerService(
            ConfigsProviderService configs,
            IBoardService boardService,
            ICoroutinePerformer coroutinePerformer,
            CharactersFactory charactersFactory,
            GameplayInputArgs gameplayInputArgs)
        {
            _configs = configs;
            _boardService = boardService;
            _coroutinePerformer = coroutinePerformer;
            _charactersFactory = charactersFactory;
            _gameplayInputArgs = gameplayInputArgs;
        }
        
        private LevelConfig LevelConfig => _configs.Get<LevelsConfig>().Levels[_gameplayInputArgs.LevelIndex];
        public bool Enabled { get; private set; }
        
        public void Enable()
        {
            Enabled = true;
        }

        public void Disable()
        {
            Enabled = false;
        }

        public void Initialize()
        {
            _coroutinePerformer.StartPerform(SpawnProcess());
        }

        private IEnumerator SpawnProcess()
        {
            while (true)
            {
                yield return new WaitForSeconds(LevelConfig.SpawnRate);

                yield return new WaitUntil(() => Enabled);
                
                if (_boardService.TryGetFreeHole(out IHole hole) == false)
                    yield return null;
                
                if (_boardService.CanSetupCharacter(hole))
                    _boardService.SetupCharacter(hole, _charactersFactory.Create(GetRandomCharacterConfig()));
            }
        }

        private CharacterConfig GetRandomCharacterConfig()
        {
            IReadOnlyList<CharacterConfig> characters = LevelConfig.Characters;
            int randomIndex = Random.Range(0, characters.Count);
            
            return characters[randomIndex];
        }
    }
}
