using System;
using System.Collections.Generic;

namespace _Project.Develop.Runtime.Utils.Reactive.Core
{
    internal class SubscriptionBuffer<TSubscriber>
    {
        private readonly List<TSubscriber> _subscribers = new();
        private readonly List<TSubscriber> _toAdd = new();
        private readonly List<TSubscriber> _toRemove = new();

        internal void Sync()
        {
            foreach (TSubscriber subscriber in _toAdd)
                _subscribers.Add(subscriber);
            
            _toAdd.Clear();

            foreach (TSubscriber subscriber in _toRemove)
                _subscribers.Remove(subscriber);
            
            _toRemove.Clear();
        }

        internal void Invoke(Action<TSubscriber> action)
        {
            foreach (TSubscriber subscriber in _subscribers)
                action(subscriber);
        }

        internal void AddSubscriber(TSubscriber subscriber)
        {
            _toAdd.Add(subscriber);
        }

        internal void RemoveSubscriber(TSubscriber subscriber)
        {
            _toRemove.Add(subscriber);
        }
    }
}
