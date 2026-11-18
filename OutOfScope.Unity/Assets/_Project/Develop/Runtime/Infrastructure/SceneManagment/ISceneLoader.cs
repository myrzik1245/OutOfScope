using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public interface ISceneLoader
    {
        void Load(string sceneKey, LoadSceneMode mode = LoadSceneMode.Single);
    }
}
