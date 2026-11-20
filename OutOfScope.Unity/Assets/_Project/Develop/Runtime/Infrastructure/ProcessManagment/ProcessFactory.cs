using _Project.Develop.Runtime.Infrastructure.CoroutineManagment;

namespace _Project.Develop.Runtime.Infrastructure.ProcessManagment
{
    public class ProcessFactory
    {
        private readonly ICoroutinePerformer _coroutinePerformer;

        public ProcessFactory(ICoroutinePerformer coroutinePerformer)
        {
            _coroutinePerformer = coroutinePerformer;
        }

        public IProcess CreateProcess(float time)
        {
            return new Process(_coroutinePerformer, time);
        }
    }
}
