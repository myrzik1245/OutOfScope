using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public class SimpleSceneLoader : ISceneLoader
    {
        public void Load<TArgs>(string sceneKey, TArgs args, LoadSceneMode mode = LoadSceneMode.Single)
        {
            IDisposable argsRegistration = LifetimeScope.Enqueue(builder => builder.RegisterInstance(args));
            
            AsyncOperation loadSceneOperation = SceneManager.LoadSceneAsync(sceneKey, mode);

            loadSceneOperation.completed += _ => argsRegistration.Dispose();
        }
    }
}
