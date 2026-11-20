using System;

namespace _Project.Develop.Runtime.Infrastructure.ProcessManagment
{
    public interface IProcess : IReadOnlyProcess
    {
        void Start(Action callback = null);
        void Stop();
    }
}
