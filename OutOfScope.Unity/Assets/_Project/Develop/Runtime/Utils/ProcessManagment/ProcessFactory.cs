using _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.CoroutineManagment;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.ProcessManagment
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
