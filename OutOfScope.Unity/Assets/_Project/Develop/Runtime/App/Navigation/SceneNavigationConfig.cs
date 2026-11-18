using UnityEditor;
using UnityEngine;

namespace _Project.Develop.Runtime.App.Navigation
{
    [CreateAssetMenu(menuName = "Configs/Core/SceneNavigationConfig", fileName = "SceneNavigationConfig")]
    public class SceneNavigationConfig : ScriptableObject
    {
        [SerializeField] private SceneAsset _mainMenuScene;
        [SerializeField] private SceneAsset _gameplayScene;
        
        public string MainMenuSceneName => _mainMenuScene.name;
        public string GameplaySceneName => _gameplayScene.name;
    }
}
