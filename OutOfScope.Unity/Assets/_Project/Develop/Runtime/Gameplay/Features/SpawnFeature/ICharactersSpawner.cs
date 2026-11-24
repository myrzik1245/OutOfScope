namespace _Project.Develop.Runtime.Gameplay.Features.SpawnFeature
{
    public interface ICharactersSpawner
    {
        bool Enabled { get; }
        public void Enable();
        public void Disable();
    }
}
