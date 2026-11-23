namespace _Project.Develop.Runtime.Infrastructure.InputService
{
    public interface IKey
    {
        bool Down { get; }
        bool Up { get; }
        bool Pressing { get; }
    }
}
