using _Project.Develop.Runtime.Utils.Reactive.Core;
using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utils.Reactive.Variable
{
    public class ReactiveVariable<T> : IReadOnlyReactiveVariable<T>
    {
        private readonly SubscriptionBuffer<Subscriber<T>> _buffer = new();
        private readonly IEqualityComparer<T> _comparer;
        private T _value;

        public ReactiveVariable(T value = default) : this(EqualityComparer<T>.Default, value)
        {
        }

        public ReactiveVariable(IEqualityComparer<T> comparer, T value = default)
        {
            _comparer = comparer;
            Value = value;
        }

        public T Value {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;
                
                if (_comparer.Equals(_value, oldValue) == false)
                    Invoke(_value);
            }
        }

        public IDisposable Subscribe(Action<T> action)
        {
            Subscriber<T> subscriber = new(action, _buffer.RemoveSubscriber);
            
            _buffer.AddSubscriber(subscriber);
            
            return subscriber;
        }
        
        private void Invoke(T newValue)
        {
            _buffer.Sync();
            _buffer.Invoke(subscriber => subscriber.Invoke(newValue));
        }
    }
    
    public class ReactiveVariable<T, K> : IReadOnlyReactiveVariable<T, T> where K : T
    {
        private readonly SubscriptionBuffer<Subscriber<T, T>> _buffer;
        private readonly IEqualityComparer<T> _comparer;
        private T _value;

        public ReactiveVariable(T value = default) : this(EqualityComparer<T>.Default, value)
        {
        }

        public ReactiveVariable(IEqualityComparer<T> comparer, T value = default)
        {
            _comparer = comparer;
            Value = value;
        }

        public T Value {
            get => _value;
            set
            {
                T oldValue = _value;
                _value = value;
                
                if (_comparer.Equals(_value, oldValue) == false)
                    Invoke(_value, oldValue);
            }
        }

        public IDisposable Subscribe(Action<T, T> action)
        {
            Subscriber<T, T> subscriber = new(action, _buffer.RemoveSubscriber);
            
            _buffer.AddSubscriber(subscriber);
            
            return subscriber;
        }
        
        private void Invoke(T newValue, T oldValue)
        {
            _buffer.Sync();
            _buffer.Invoke(subscriber => subscriber.Invoke(newValue, oldValue));
        }
    }
}
