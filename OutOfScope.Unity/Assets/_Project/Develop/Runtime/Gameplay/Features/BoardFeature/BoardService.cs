using _Project.Develop.Runtime.Gameplay.Features.CharactersFeature;
using _Project.Develop.Runtime.Gameplay.Features.HoleFeature;
using _Project.Develop.Runtime.Utils.Reactive.Event;
using System;
using System.Collections.Generic;

using Random = UnityEngine.Random;

namespace _Project.Develop.Runtime.Gameplay.Features.BoardFeature
{
    public class BoardService : IBoardService, IDisposable
    {
        private readonly Dictionary<int, IHole> _holesMap = new();

        private List<IDisposable> _subscriptions = new();
        
        private readonly ReactiveEvent<ICharacter> _characterDied = new();
        private readonly ReactiveEvent _characterHided = new();

        public BoardService(IHoleContainer holesContainer)
        {
            int i = 1;
            
            foreach (IHole hole in holesContainer.Holes)
            {
                _holesMap.Add(i, hole);

                _subscriptions.Add(hole.CharacterDied.Subscribe(character => _characterDied.Invoke(character)));
                _subscriptions.Add(hole.CharacterHided.Subscribe(() => _characterHided.Invoke()));
                
                i++;
            }
        }

        public IReadOnlyReactiveEvent CharacterHided => _characterHided;
        public IReadOnlyReactiveEvent<ICharacter> CharacterDied => _characterDied;

        public bool TryDamage(int index, int damage)
        {
            if (_holesMap.TryGetValue(index, out IHole hole) == false)
                return false;
            
            return hole.TryDamage(damage);
        }

        public bool TryGetFreeHole(out IHole freeHole)
        {
            List<IHole> freeHoles = new();
            freeHole = null;            
            
            foreach (IHole hole in _holesMap.Values)
                if (hole.CanSetupCharacter())
                    freeHoles.Add(hole);

            if (freeHoles.Count <= 0)
                return false;
            
            int randomIndex = Random.Range(0, freeHoles.Count);
            freeHole = freeHoles[randomIndex];
            
            return true;
        }

        public bool CanSetupCharacter(IHole hole)
        {
            return hole.CanSetupCharacter();
        }

        public void SetupCharacter(IHole hole, ICharacter character)
        {
            hole.SetupCharacter(character);
        }

        public void Dispose()
        {
            foreach (IDisposable subscription in _subscriptions)
                subscription.Dispose();
            
            _subscriptions.Clear();
        }
    }
}
