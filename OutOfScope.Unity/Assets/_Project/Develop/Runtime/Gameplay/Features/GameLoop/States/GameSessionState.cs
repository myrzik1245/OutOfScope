using _Project.Develop.Runtime.Meta.Features.WalletFeature;
using _Project.Develop.Runtime.Utils.StateMachineCore.States;

namespace _Project.Develop.Runtime.Gameplay.Features.GameLoop.States
{
    public class GameSessionState : State, IUpdatableState
    {
        private readonly GameSession _gameSession;

        public GameSessionState(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        public override void Enter()
        {
            _gameSession.Start();
            
            base.Enter();
        }

        public void Update(float deltaTime)
        {
        }

        public override void Exit()
        {
            _gameSession.Stop();
            
            base.Exit();
        }
    }
}
