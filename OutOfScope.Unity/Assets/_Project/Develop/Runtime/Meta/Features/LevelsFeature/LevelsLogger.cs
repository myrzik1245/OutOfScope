using _Project.Develop.Runtime.Meta.Features.LevelsProgressionFeature;
using System.Text;
using UnityEngine;

namespace _Project.Develop.Runtime.Meta.Features.LevelsFeature
{
    public class LevelsLogger
    {
        private readonly LevelsProgressionService _levelsProgressionService;

        public LevelsLogger(LevelsProgressionService levelsProgressionService)
        {
            _levelsProgressionService = levelsProgressionService;
        }

        public void Show()
        {
            StringBuilder builder = new();

            for (int i = 0; i < _levelsProgressionService.Levels.Count; i++)
            {
                IReadOnlyLevel level = _levelsProgressionService.Levels[i];
                
                builder.AppendLine($"Level {i + 1} | is compleated {level.IsCompleated} | is unlocked {level.IsUnlocked}");
            }

            Debug.Log(builder.ToString());
        }
    }
}
