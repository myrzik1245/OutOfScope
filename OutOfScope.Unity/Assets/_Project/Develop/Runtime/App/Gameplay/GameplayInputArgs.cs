using _Project.Develop.Runtime.Infrastructure.SceneManagment;

namespace _Project.Develop.Runtime.App.Gameplay
{
    public class GameplayInputArgs : ISceneInputArgs
    {
        public GameplayInputArgs(int levelIndex)
        {
            LevelIndex = levelIndex;
        }

        public int LevelIndex { get; private set; }
    }
}
