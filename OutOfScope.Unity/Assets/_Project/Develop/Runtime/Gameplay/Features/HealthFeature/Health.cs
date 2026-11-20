using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;

namespace _Project.Develop.Runtime.Gameplay.Features.HealthFeature
{
    public class Health : IReadOnlyHealth, IDamageable, IAlive, IKillable, IDiedNotifier
    {
        private readonly ReactiveVariable<int> _currentHealth;
        private readonly ReactiveVariable<int> _maxHealth;
        private readonly ReactiveVariable<bool> _isDead = new();
        private readonly ReactiveEvent _died = new();

        public Health(int startHealth, int maxHealth)
        {
            _currentHealth = new ReactiveVariable<int>(startHealth);
            _maxHealth = new ReactiveVariable<int>(maxHealth);
        }

        public IReadOnlyReactiveVariable<int> CurrentHealth => _currentHealth;
        public IReadOnlyReactiveVariable<int> MaxHealth => _maxHealth;
        public IReadOnlyReactiveVariable<bool> IsDead => _isDead;
        public IReadOnlyReactiveEvent Died => _died;

        public bool CanTakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException($"{nameof(damage)} <= 0");

            return _isDead.Value == false;
        }
        
        public void TakeDamage(int damage)
        {
            if (CanTakeDamage(damage) == false)
                throw new InvalidOperationException();
            
            _currentHealth.Value = Math.Clamp(_currentHealth.Value - damage, 0, _maxHealth.Value);

            if (_currentHealth.Value <= 0)
            {
                _isDead.Value = true;
                _died.Invoke();
            }
        }

        public void Kill()
        {
            _currentHealth.Value = 0;
            _isDead.Value = true;
        }

    }
}
