using _Project.Develop.Runtime.Utils.StateMachineCore;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop
{
    public class GameplayStateMachine : StateMachine<IUpdatableState>, IUpdatableState
    {
        public override void Update(float deltaTime)
        {
            CurrentState?.Update(deltaTime);
            
            base.Update(deltaTime);
        }
    }
}
