using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.Reactive.Event;
using System;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.StateMachineCore.States
{
    public interface IState : IDisposable
    {
        IReadOnlyReactiveEvent Entered { get; }
        IReadOnlyReactiveEvent Exited { get; }

        void Enter();
        void Exit();
    }
}
