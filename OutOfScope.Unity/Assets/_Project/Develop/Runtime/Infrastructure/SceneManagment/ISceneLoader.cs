using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine.SceneManagement;
using VContainer;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public interface ISceneLoader
    {
        UniTask<Scene> LoadAsync(
            string sceneKey,
            CancellationToken cancellationToken,
            Action<IContainerBuilder> extraRegistrations = null,
            IProgress<float> progress = null);

        UniTask UnloadAsync(string sceneKey);
    }
}
