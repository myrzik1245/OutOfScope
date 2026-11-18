using UnityEngine.SceneManagement;

namespace _Project.Develop.Runtime.Infrastructure.SceneManagment
{
    public class SimpleSceneLoader : ISceneLoader
    {
        public void Load(string sceneKey, LoadSceneMode mode = LoadSceneMode.Single)
        {
            SceneManager.LoadScene(sceneKey, mode);
        }
    }
}
