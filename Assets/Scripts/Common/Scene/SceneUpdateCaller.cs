using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/SceneUpdateCaller")]
    public class SceneUpdateCaller : ScriptableObject {

        [SerializeField]
        SceneBase unloadScene;

        [SerializeField]
        SceneBase loadScene;

        [SerializeField]
        SceneUpdater sceneUpdater;

        public void UpdateScene() {
            sceneUpdater.UpdateScene(
                new SceneTransition {
                    UnloadScene = unloadScene,
                    LoadScene = loadScene
                }
            );
        }

    }
}