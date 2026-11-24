namespace _Project.Develop.Runtime.Meta.Features.LevelsFeature
{
    public class Level : IReadOnlyLevel
    {
        public bool IsCompleated { get; private set; }
        public bool IsUnlocked { get; private set; }

        public void Compleate()
        {
            IsCompleated = true;
        }

        public void Unlock()
        {
            IsUnlocked = true;
        }
    }
}
