using _Project.Develop.Runtime.Utils.Reactive.Event;
using System.Collections;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utils.Reactive.List
{
    public class ReactiveList<T> : IEnumerable<T>
    {
        private List<T> _list = new();

        private ReactiveEvent<T> _changed = new();
        private ReactiveEvent<T> _removed = new();
        private ReactiveEvent<T> _added = new();
        
        public IReadOnlyReactiveEvent<T> Changed => _changed;
        public IReadOnlyReactiveEvent<T> Removed => _removed;
        public IReadOnlyReactiveEvent<T> Added => _added;

        public T this[int index]
        {
            get => _list[index];
            set 
            {
                _list[index] = value;
                _changed.Invoke(value);
            }
        }
        
        public void Add(T item)
        {
            _list.Add(item);
            
            _added.Invoke(item);
            _changed.Invoke(item);
        }

        public void Remove(T item)
        {
            _list.Remove(item);
            
            _removed.Invoke(item);
            _changed.Invoke(item);
        }

        public void Clear()
        {
            foreach (T item in _list.ToArray())
                Remove(item);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
