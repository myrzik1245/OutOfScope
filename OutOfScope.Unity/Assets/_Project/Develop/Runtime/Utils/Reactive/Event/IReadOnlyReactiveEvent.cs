using System;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.Reactive.Event
{
    public interface IReadOnlyReactiveEvent
    {
        IDisposable Subscribe(Action action);
    }
    
    public interface IReadOnlyReactiveEvent<T>
    {
        IDisposable Subscribe(Action<T> action);
    }
    
    public interface IReadOnlyReactiveEvent<T, K>
    {
        IDisposable Subscribe(Action<T, K> action);
    }
}
