using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop.States
{
    public class LoseState : State, IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly SceneNavigation _sceneNavigation;
        private readonly GameplayInputArgs _gameplayInputArgs;

        public LoseState(
            IInputService inputService,
            SceneNavigation sceneNavigation,
            GameplayInputArgs gameplayInputArgs)
        {
            _inputService = inputService;
            _sceneNavigation = sceneNavigation;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public override void Enter()
        {
            Debug.Log("You lose");
            
            base.Enter();
        }

        public void Update(float deltaTime)
        {
            if (_inputService.Exit.Down)
                _sceneNavigation.OpenMainMenu();
            if (_inputService.Continue.Down)
                _sceneNavigation.OpenGameplay(_gameplayInputArgs.LevelIndex);
        }
    }
}
