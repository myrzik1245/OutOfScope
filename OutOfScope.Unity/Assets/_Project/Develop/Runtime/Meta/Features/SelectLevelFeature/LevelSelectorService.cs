using _Project.Develop.Runtime.App.Gameplay;
using _Project.Develop.Runtime.App.Navigation;
using _Project.Develop.Runtime.Infrastructure.InputService;
using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using System;
using System.Collections.Generic;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Meta.Features.SelectLevelFeature
{
    public class LevelSelectorService : IInitializable, IDisposable
    {
        private readonly IInputService _inputService;
        private readonly SceneNavigation _sceneNavigation;
        private readonly LevelsProgressionService _levelsProgressionService;
        
        private readonly List<IDisposable> _subscriptions = new();

        public LevelSelectorService(
            IInputService inputService,
            SceneNavigation sceneNavigation,
            LevelsProgressionService levelsProgressionService)
        {
            _inputService = inputService;
            _sceneNavigation = sceneNavigation;
            _levelsProgressionService = levelsProgressionService;
        }

        public void Initialize()
        {
            _subscriptions.Add(_inputService.NumPadKeyPressed.Subscribe(OnNumpadKeyPressed));
        }

        public void Dispose()
        {
            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();
            
            _subscriptions.Clear();
        }

        private void OnNumpadKeyPressed(int number)
        {
            int index = number - 1;

            if (_levelsProgressionService.IsLevelUnlocked(index))
                _sceneNavigation.OpenGameplay(new GameplayInputArgs(index));
        }
    }
}
