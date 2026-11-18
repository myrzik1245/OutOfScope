using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;

namespace _Project.Develop.Runtime.Utils.ProcessManagment
{
    public interface IProcess
    {
        IReadOnlyReactiveVariable<float> Progress { get; }
        IReadOnlyReactiveEvent Ended { get; }

        void Start(Action callback = null);
    }
}
