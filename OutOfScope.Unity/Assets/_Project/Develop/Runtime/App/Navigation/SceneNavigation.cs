using _Project.Develop.Runtime.Infrastructure._Project.Develop.Runtime.Infrastructure.SceneManagment;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation
{
    public class SceneNavigation
    {
        private readonly ISceneLoader _sceneLoader;

        public SceneNavigation(ISceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        public void OpenMainMenu()
        {
            _sceneLoader.Load("MainMenu");
        }
        
        public void OpenGameplay()
        {
            _sceneLoader.Load("Gameplay");
        }
    }
}
