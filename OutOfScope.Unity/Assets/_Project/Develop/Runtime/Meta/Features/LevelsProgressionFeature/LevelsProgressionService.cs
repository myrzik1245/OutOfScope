using _Project.Develop.Runtime.Infrastructure.ConfigsManagment;
using _Project.Develop.Runtime.Meta.Features.LevelsFeature;
using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature
{
    public class LevelsProgressionService
    {
        private readonly ConfigsProviderService _configsProviderService;
        private readonly List<Level> _levels = new();
        
        public LevelsProgressionService(ConfigsProviderService configsProviderService)
        {
            _configsProviderService = configsProviderService;
        }

        public IReadOnlyList<IReadOnlyLevel> Levels => _levels;
        
        private LevelsConfig LevelsConfig => _configsProviderService.Get<LevelsConfig>();
        
        public void Initialize()
        {
            for (int i = 0; i < LevelsConfig.Levels.Count; i++)
                _levels.Add(new Level());
        }

        public void CompleateLevel(int levelIndex)
        {
            if (IndexInRange(levelIndex) == false)
                return;

            _levels[levelIndex].Compleate();
        }

        public void UnlockLevel(int levelIndex)
        {
            if (IndexInRange(levelIndex) == false)
                return;
            
            _levels[levelIndex].Unlock();
        }
        
        public bool IsLevelUnlocked(int levelIndex)
        {
            if (IndexInRange(levelIndex) == false)
                throw new ArgumentOutOfRangeException(nameof(levelIndex));

            if (levelIndex == 0)
                return true;

            return _levels[levelIndex].IsUnlocked;
        }
        
        private bool IndexInRange(int index)
        {
            return index >= 0 && index < _levels.Count;
        }
    }
}
