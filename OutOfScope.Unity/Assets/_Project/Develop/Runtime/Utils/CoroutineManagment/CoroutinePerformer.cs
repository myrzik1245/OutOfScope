using System.Collections;
using UnityEngine;

namespace _Project.Develop.Runtime.Utils._Project.Develop.Runtime.Utils.CoroutineManagment
{
    public class CoroutinePerformer : MonoBehaviour, ICoroutinePerformer
    {
        public Coroutine StartPerform(IEnumerator coroutine)
        {
            return StartCoroutine(coroutine);
        }

        public void StopPerform(Coroutine coroutine)
        {
            StopCoroutine(coroutine);
        }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}