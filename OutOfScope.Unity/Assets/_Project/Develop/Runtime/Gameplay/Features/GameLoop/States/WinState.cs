using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop.States
{
    public class WinState : State, IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly SceneNavigation _sceneNavigation;
        private readonly Wallet _wallet;
        private readonly GameSession _gameSession;
        private readonly LevelsProgressionService _levelsProgressionService;
        private readonly GameplayInputArgs _gameplayInputArgs;

        public WinState(
            IInputService inputService,
            SceneNavigation sceneNavigation,
            Wallet wallet,
            GameSession gameSession,
            LevelsProgressionService levelsProgressionService,
            GameplayInputArgs gameplayInputArgs)
        {
            _inputService = inputService;
            _sceneNavigation = sceneNavigation;
            _wallet = wallet;
            _gameSession = gameSession;
            _levelsProgressionService = levelsProgressionService;
            _gameplayInputArgs = gameplayInputArgs;
        }

        public override void Enter()
        {
            Debug.Log("You win");

            foreach (IReadOnlyWalletSlot sessionWalletSlot in _gameSession.SessionWallet.Slots)
                _wallet.Add(sessionWalletSlot.CurrencyType, sessionWalletSlot.Amount.Value);

            _levelsProgressionService.CompleateLevel(_gameplayInputArgs.LevelIndex);
            _levelsProgressionService.UnlockLevel(_gameplayInputArgs.LevelIndex + 1);
        }

        public void Update(float deltaTime)
        {
            if (_inputService.Continue.Down)
                _sceneNavigation.OpenMainMenu();
        }
    }
}
