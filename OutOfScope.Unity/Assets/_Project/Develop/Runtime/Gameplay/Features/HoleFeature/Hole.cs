using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Utils.Reactive.Event;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Develop.Runtime.Gameplay.Features.HoleFeature
{
    public class Hole : MonoBehaviour, IHole
    {
        private ICharacter _character;
        
        private readonly ReactiveEvent _characterHided = new();
        private readonly ReactiveEvent<ICharacter> _characterDied = new();
        private readonly List<IDisposable> _characterSubscriptions = new();
        
        public bool HasCharacter => _character != null;

        public IReadOnlyReactiveEvent CharacterHided => _characterHided;
        public IReadOnlyReactiveEvent<ICharacter> CharacterDied => _characterDied;

        public bool CanSetupCharacter()
        {
            return HasCharacter == false;
        }
        
        public void SetupCharacter(ICharacter character)
        {
            if (CanSetupCharacter() == false)
                throw new InvalidOperationException();
            
            _character = character;
            _character.Setup(transform);
            
            _characterSubscriptions.Add(_character.Hided.Subscribe(OnHided));
            _characterSubscriptions.Add(_character.Died.Subscribe(OnDied));
            
            _character.Show();
        }

        public bool TryDamage(int damage)
        {
            if (HasCharacter == false)
                return false;
            
            if (_character.CanTakeDamage(damage) == false)
                return false;
            
            _character.TakeDamage(damage);

            return true;
        }
        
        private void OnHided()
        {
            _characterHided.Invoke();
            ReleaseCharacter();
        }

        private void OnDied()
        {
            _characterDied.Invoke(_character);
            ReleaseCharacter();
        }

        private void ReleaseCharacter()
        {
            ClearCharacterSubscriptions();
            _character = null;
        }

        private void OnDestroy()
        {
            ClearCharacterSubscriptions();
        }

        private void ClearCharacterSubscriptions()
        {
            foreach (IDisposable characterSubscription in _characterSubscriptions)
                characterSubscription.Dispose();
            
            _characterSubscriptions.Clear();
        }
    }
}
