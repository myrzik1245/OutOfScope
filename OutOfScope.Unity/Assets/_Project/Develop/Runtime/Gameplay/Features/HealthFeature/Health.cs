using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public class Health : IReadOnlyHealth, IDamageable
    {
        private readonly ReactiveVariable<int> _currentHealth;
        private readonly ReactiveVariable<int> _maxHealth;

        public Health(int startHealth, int maxHealth)
        {
            _currentHealth = new ReactiveVariable<int>(startHealth);
            _maxHealth = new ReactiveVariable<int>(maxHealth);
        }

        public IReadOnlyReactiveVariable<int> CurrentHealth => _currentHealth;
        public IReadOnlyReactiveVariable<int> MaxHealth => _maxHealth;

        public void TakeDamage(int damage)
        {
            if (damage <= 0)
                throw new InvalidOperationException("damage must be greater than 0");
            
            _currentHealth.Value = Math.Clamp(_currentHealth.Value - damage, 0, _maxHealth.Value);
        }
    }
}
