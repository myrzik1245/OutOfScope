using _Project.Develop.Runtime.Gameplay.Features.GameLoop;
using System;
using UnityEngine;
using VContainer.Unity;

namespace _Project.Develop.Runtime.App.Gameplay
{
    public class GameplayBootstrap : IStartable, ITickable, IDisposable
    {
        private readonly GameplayStatesFactory _gameplayStatesFactory;

        private GameplayStateMachine _gameplayStateMachine;
        
        public GameplayBootstrap(GameplayStatesFactory gameplayStatesFactory)
        {
            _gameplayStatesFactory = gameplayStatesFactory;
        }

        public void Start()
        {
            _gameplayStateMachine = _gameplayStatesFactory.CreateGameplayStateMachine();
            _gameplayStateMachine.Enter();
        }

        public void Tick()
        {
            _gameplayStateMachine.Update(Time.deltaTime);
        }

        public void Dispose()
        {
            _gameplayStateMachine?.Dispose();
        }
    }
}
