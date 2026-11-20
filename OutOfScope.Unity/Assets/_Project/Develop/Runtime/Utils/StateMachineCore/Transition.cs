using _Project.Develop.Runtime.Utils.Conditions;
using _Project.Develop.Runtime.Utils.StateMachineCore.Node;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;

namespace _Project.Develop.Runtime.Utils.StateMachineCore
{
    public class Transition<TState>where TState : class, IState
    {
        public Transition(StateNode<TState> toState, ICondition condition)
        {
            ToState = toState;
            Condition = condition;
        }

        public StateNode<TState> ToState { get; }
        public ICondition Condition { get; }
    }
}
