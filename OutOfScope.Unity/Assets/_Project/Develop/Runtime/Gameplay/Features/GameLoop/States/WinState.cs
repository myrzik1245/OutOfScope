using _Project.Develop.Runtime.App.MainMenu;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using _Project.Develop.Runtime.Meta.Features.WalletFeature.Slot;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;
using Codice.CM.SEIDInfo;
using System;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop.States
{
    public class WinState : State, IUpdatableState
    {
        private readonly IInputService _inputService;
        private readonly SceneNavigation _sceneNavigation;
        private readonly Wallet _wallet;
        private readonly GameSession _gameSession;

        public WinState(
            IInputService inputService,
            SceneNavigation sceneNavigation,
            Wallet wallet,
            GameSession gameSession)
        {
            _inputService = inputService;
            _sceneNavigation = sceneNavigation;
            _wallet = wallet;
            _gameSession = gameSession;
        }

        public override void Enter()
        {
            Debug.Log("You win");
            
            foreach (IReadOnlyWalletSlot sessionWalletSlot in _gameSession.SessionWallet.Slots)
                _wallet.Add(sessionWalletSlot.CurrencyType, sessionWalletSlot.Amount.Value);
        }
        
        public void Update(float deltaTime)
        {
            if (_inputService.Continue.Down)
                _sceneNavigation.OpenMainMenu(new MainMenuInputArgs());
        }
    }
}
