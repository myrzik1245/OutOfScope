using _Project.Develop.Runtime.Utils.ConditionsManagment;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;

namespace _Project.Develop.Runtime.Utils.StateMachineCore
{
    public interface IStateMachineOptions<TState> where TState : class, IState
    {
        IStateMachineOptions<TState> AddState(TState state);
        IStateMachineOptions<TState> AddTransition(TState from, TState to, ICondition condition);
    }
}
