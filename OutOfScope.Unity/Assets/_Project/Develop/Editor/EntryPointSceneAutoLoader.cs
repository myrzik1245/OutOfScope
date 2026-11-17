using UnityEditor;
using UnityEditor.SceneManagement;

namespace _Project.Develop.Editor
{
    [InitializeOnLoad]
    public static class EntryPointSceneAutoLoader
    {
        private const string MenuPath = "Tools/Project/PlayFromeBootstrap";
        private const string EnabledKey = "Project.PlayFromeBootstrap";

        static EntryPointSceneAutoLoader()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static bool IsEnabled => EditorPrefs.GetBool(EnabledKey, true);

        [MenuItem(MenuPath)]
        private static void Toggle()
        {
            EditorPrefs.SetBool(EnabledKey, IsEnabled == false);
        }

        [MenuItem(MenuPath, true)]
        private static bool ToggleValidate()
        {
            Menu.SetChecked(MenuPath, IsEnabled);

            return true;
        }
        
        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
                return;

            if (IsEnabled == false)
                EditorSceneManager.playModeStartScene = null;
            else
                EditorSceneManager.playModeStartScene = FindStartScene();
        }

        private static SceneAsset FindStartScene()
        {
            foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
                if (scene.enabled)
                    return AssetDatabase.LoadAssetAtPath<SceneAsset>(scene.path);

            return null;
        }
    }
}
