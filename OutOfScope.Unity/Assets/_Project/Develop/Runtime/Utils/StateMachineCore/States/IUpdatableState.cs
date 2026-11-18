namespace _Project.Develop.Runtime.Utils.StateMachineCore.States
{
    public interface IUpdatableState : IState
    {
        void Update(float deltaTime);
    }
}
