using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.StateMachineCore.States
{
    public abstract class State : IState
    {
        public IReadOnlyReactiveEvent Entered => _entered;
        public IReadOnlyReactiveEvent Exited => _exited;

        private ReactiveEvent _entered = new ReactiveEvent();
        private ReactiveEvent _exited = new ReactiveEvent();

        public virtual void Enter()
        {
            _entered.Invoke();
        }

        public virtual void Exit()
        {
            _exited.Invoke();
        }
        
        public virtual void Dispose()
        {
            _exited.Invoke();
        }
    }
}
