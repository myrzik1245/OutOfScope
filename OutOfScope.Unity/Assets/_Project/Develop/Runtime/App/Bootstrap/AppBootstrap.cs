using _Project.Develop.Runtime._Project.Develop.Runtime.App.Navigation;
using VContainer.Unity;

namespace _Project.Develop.Runtime._Project.Develop.Runtime.App.Bootstrap
{
    public class AppBootstrap : IStartable
    {
        private SceneNavigation _sceneNavigation;

        public AppBootstrap(SceneNavigation sceneNavigation)
        {
            _sceneNavigation = sceneNavigation;
        }

        public void Start()
        {
            SetupApp();
            
            _sceneNavigation.OpenMainMenu();
        }

        private void SetupApp()
        {
        }
    }
}
