using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;

namespace _Project.Develop.Runtime.Infrastructure.ProcessManagment
{
    public interface IReadOnlyProcess
    {
        IReadOnlyReactiveVariable<float> Progress { get; }
        IReadOnlyReactiveEvent Ended { get; }
    }
}
