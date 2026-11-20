using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public interface ISceneLoader
    {
        void Load<TArgs>(string sceneKey, TArgs args, LoadSceneMode mode = LoadSceneMode.Single);
    }
}
