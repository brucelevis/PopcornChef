using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Debug/PlayOnEditorInitializer")]
    public class PlayOnEditorInitializer : ScriptableObject {

        [SerializeField]
        SceneRegister sceneRegister;

        void OnEnable() {
            EditorApplication.playModeStateChanged += HandleOnPlayModeChanged;
        }

        void OnDisable() {
            EditorApplication.playModeStateChanged -= HandleOnPlayModeChanged;
        }

        void HandleOnPlayModeChanged(PlayModeStateChange arg) {
            switch (arg) {
                case PlayModeStateChange.EnteredPlayMode:
                    OnEnterPlayOnEditor();
                    break;
                case PlayModeStateChange.ExitingPlayMode:
                    OnExitPlayOnEditor();
                    break;
            }
        }

        async void OnEnterPlayOnEditor() {
            int sceneCount = SceneManager.sceneCount;
            for (int i = 0; i < sceneCount; i++) {
                var scene = sceneRegister.Scenes[SceneManager.GetSceneAt(i).buildIndex];
                if (scene == null) continue;
                await UniTask.SwitchToMainThread();
                await scene.Initialize();
            }
        }

        async void OnExitPlayOnEditor() {
            int sceneCount = SceneManager.sceneCount;
            for (int i = 0; i < sceneCount; i++) {
                var scene = sceneRegister.Scenes[SceneManager.GetSceneAt(i).buildIndex];
                if (scene == null) continue;
                await UniTask.SwitchToMainThread();
                await scene.Finalize();
            }
        }

    }
}