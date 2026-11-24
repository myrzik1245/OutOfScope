using UnityEngine;

namespace _Project.Develop.Runtime.App.Navigation
{
    [CreateAssetMenu(menuName = "Configs/Core/SceneNavigationConfig", fileName = "SceneNavigationConfig")]
    public class SceneNavigationConfig : ScriptableObject
    {
        [field: SerializeField] public string MainMenuSceneName { get; private set; }
        [field: SerializeField] public string GameplaySceneName { get; private set; }
    }
}
