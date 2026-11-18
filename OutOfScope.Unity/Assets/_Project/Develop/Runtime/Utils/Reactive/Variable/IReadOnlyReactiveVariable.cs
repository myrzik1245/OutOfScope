using System;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.Reactive.Variable
{
    public interface IReadOnlyReactiveVariable<T>
    {
        public T Value { get; }
        
        IDisposable Subscribe(Action<T> action);
    }
    
    public interface IReadOnlyReactiveVariable<T, TK> where TK : T
    {
        public T Value { get; }
        
        IDisposable Subscribe(Action<T, TK> action);
    }
}
