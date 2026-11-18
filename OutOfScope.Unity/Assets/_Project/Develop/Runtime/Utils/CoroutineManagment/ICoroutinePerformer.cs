using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils.CoroutineManagment
{
    public interface ICoroutinePerformer
    {
        Coroutine StartPerform(IEnumerator coroutine);
        void StopPerform(Coroutine coroutine);
    }
}