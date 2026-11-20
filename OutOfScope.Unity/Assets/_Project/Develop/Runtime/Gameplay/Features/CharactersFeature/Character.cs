using _Project.Develop.Runtime.Gameplay.Features.HealthFeature;
using _Project.Develop.Runtime.Infrastructure.ProcessManagment;
using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.CharactersFeature
{
    public class Character : MonoBehaviour, ICharacter
    {
        private Health _health;
        private IProcess _hideProcess;
        private readonly List<IDisposable> _subscriptions = new();
        private readonly ReactiveEvent _hided = new();
        private readonly ReactiveEvent _showed = new();
        private readonly ReactiveEvent _died = new();

        public IReadOnlyReactiveVariable<int> CurrentHealth => _health.CurrentHealth;
        public IReadOnlyReactiveVariable<int> MaxHealth => _health.MaxHealth;
        public IReadOnlyReactiveVariable<bool> IsDead => _health.IsDead;
        public IReadOnlyReactiveEvent Showed => _showed;
        public IReadOnlyReactiveEvent Hided => _hided;
        public IReadOnlyReactiveEvent Died => _died;
        public IReadOnlyReactiveVariable<float> HideProcessProgress => _hideProcess.Progress;

        public void Initialize(IProcess hideProcess, int startHealth, int maxHealth)
        {
            _hideProcess = hideProcess;

            _health = new Health(startHealth, maxHealth);

            _subscriptions.Add(_hideProcess.Ended.Subscribe(Hide));
            _subscriptions.Add(_health.IsDead.Subscribe(OnIsDeadChanged));
        }

        public void Setup(Transform parent)
        {
            transform.SetParent(parent);
            transform.localPosition = Vector3.zero;
        }
        
        public void Show()
        {
            _hideProcess.Start();
            _showed.Invoke();
        }

        public bool CanTakeDamage(int damage)
        {
            return _health.CanTakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }

        public void Kill()
        {
            _health.Kill();
        }

        private void Hide()
        {
            _hideProcess.Stop();
            _hided.Invoke();
        }

        private void OnIsDeadChanged(bool isDead)
        {
            if (isDead)
            {
                ClearSubscriptions();
                _hideProcess.Stop();
                _died.Invoke();
            }
        }

        private void OnDestroy()
        {
            ClearSubscriptions();
        }

        private void ClearSubscriptions()
        {
            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();

            _subscriptions.Clear();
        }
    }
}
