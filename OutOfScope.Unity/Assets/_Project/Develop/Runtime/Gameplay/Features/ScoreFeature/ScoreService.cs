using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.ScoreFeature
{
    public class ScoreService
    {
        private readonly ReactiveVariable<int> _score = new();
        
        public IReadOnlyReactiveVariable<int> Score => _score;
        
        public void Add(int score)
        {
            if (score < 0)
                throw new ArgumentException("score cannot be negative");
            
            _score.Value += score;
        }
    }
}
