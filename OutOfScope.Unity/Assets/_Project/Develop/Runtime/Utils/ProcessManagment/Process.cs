using _Project.Develop.Runtime.Utils.CoroutineManagment;
using _Project.Develop.Runtime.Utils.Reactive.Event;
using _Project.Develop.Runtime.Utils.Reactive.Variable;
using System;
using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils.ProcessManagment
{
    public class Process : IProcess
    {
        private readonly ICoroutinePerformer _coroutinePerformer;
        private readonly float _time;
        private readonly ReactiveVariable<float> _progress = new();
        private readonly ReactiveEvent _ended = new();

        public Process(ICoroutinePerformer coroutinePerformer, float time)
        {
            _coroutinePerformer = coroutinePerformer;
            _time = time;
        }

        public IReadOnlyReactiveVariable<float> Progress => _progress;
        public IReadOnlyReactiveEvent Ended => _ended;
        
        public void Start(Action callback = null)
        {
            _coroutinePerformer.StartPerform(Run(callback));
        }

        private IEnumerator Run(Action callback = null)
        {
            float elapsedTime = 0;
            
            while (elapsedTime < _time)
            {
                float deltaTime = Time.deltaTime;
                
                elapsedTime += deltaTime;
                _progress.Value = elapsedTime / _time;

                OnRun(deltaTime);
                
                yield return null;
            }

            _ended.Invoke();
            callback?.Invoke();
        }

        protected virtual void OnRun(float deltaTime)
        {
        }
    }
}
