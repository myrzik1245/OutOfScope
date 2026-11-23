using _Project.Develop.Runtime.Utils.Reactive.Event;

namespace _Project.Develop.Runtime.Infrastructure.InputService
{
    public interface IInputService
    {
        IReadOnlyReactiveEvent<int> NumPadKeyPressed { get; }
        IKey Exit { get; }
        IKey Continue { get; }
    }
}
