namespace _Project.Develop.Runtime.App.Gameplay
{
    public class GameplayInputArgs
    {
        public GameplayInputArgs(int levelIndex)
        {
            LevelIndex = levelIndex;
        }

        public int LevelIndex { get; private set; }
    }
}
