using _Project.Develop.Runtime.Utils.Reactive.Core;
using System;

namespace _Project.Develop.Runtime.Utils.Reactive.Event
{
    public class ReactiveEvent :  IReadOnlyReactiveEvent
    {
        private readonly SubscriptionBuffer<Subscriber> _buffer =  new();
        
        public IDisposable Subscribe(Action action)
        {
            Subscriber subscriber = new(action, _buffer.RemoveSubscriber);
            _buffer.AddSubscriber(subscriber);
            
            return subscriber;
        }

        public void Invoke()
        {
            _buffer.Sync();
            _buffer.Invoke(subscriber => subscriber.Invoke());
        }
    }

    public class ReactiveEvent<T> : IReadOnlyReactiveEvent<T>
    {
        private readonly SubscriptionBuffer<Subscriber<T>> _buffer = new();
        
        public IDisposable Subscribe(Action<T> action)
        {
            Subscriber<T> subscriber = new(action, _buffer.RemoveSubscriber);
            
            _buffer.AddSubscriber(subscriber);
            
            return subscriber;
        }

        public void Invoke(T arg)
        {
            _buffer.Sync();
            _buffer.Invoke(subscriber => subscriber.Invoke(arg));
        }
    }
    
    public class ReactiveEvent<T, K> : IReadOnlyReactiveEvent<T, K>
    {
        private readonly  SubscriptionBuffer<Subscriber<T, K>> _buffer = new();
        
        public IDisposable Subscribe(Action<T, K> action)
        {
            Subscriber<T, K> subscriber = new(action, _buffer.RemoveSubscriber);
            
            _buffer.AddSubscriber(subscriber);

             return subscriber;
        }

        public void Invoke(T arg, K arg1)
        {
            _buffer.Sync();
            _buffer.Invoke(subscriber => subscriber.Invoke(arg, arg1));
        }
    }
}
