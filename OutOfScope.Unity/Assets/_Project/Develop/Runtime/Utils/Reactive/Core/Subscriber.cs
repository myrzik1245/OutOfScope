using System;

namespace _Project.Develop.Runtime.Utils.Reactive.Core
{

    public class Subscriber : IDisposable
    {
        private readonly Action _action;
        private readonly Action<Subscriber> _onDispose;


        public Subscriber(Action action, Action<Subscriber> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke()
        {
            _action?.Invoke();
        }
        
        public void Dispose()
        {
            _onDispose?.Invoke(this);
        }
    }
    
    public class Subscriber<T> : IDisposable
    {
        private readonly Action<Subscriber<T>> _onDispose;
        private readonly Action<T> _action;
        
        public Subscriber(Action<T> action, Action<Subscriber<T>> onDispose)
        {
            _onDispose = onDispose;
            _action = action;
        }

        public void Invoke(T arg)
        {
            _action?.Invoke(arg);
        }
        
        public void Dispose()
        {
            _onDispose?.Invoke(this);
        }
    }

    public class Subscriber<T, K> : IDisposable
    {
        private readonly Action<T, K> _action;
        private readonly Action<Subscriber<T, K>> _onDispose;
        
        public Subscriber(Action<T, K> action, Action<Subscriber<T, K>> onDispose)
        {
            _action = action;
            _onDispose = onDispose;
        }

        public void Invoke(T arg, K arg1)
        {
            _action?.Invoke(arg, arg1);
        }

        public void Dispose()
        {
            _onDispose?.Invoke(this);
        }
    }
}
