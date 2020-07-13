using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/SceneUpdater")]
    public class SceneUpdater : ScriptableObject {

        [SerializeReference]
        List<ISceneLoadHandler> sceneLoadHandlers;

        [SerializeField]
        SceneTransitionGameEvent OnStartLoadScene;

        [SerializeField]
        SceneTransitionGameEvent OnFinishLoadScene;

        [SerializeField]
        SceneTransitionGameEvent OnStartUnloadScene;

        [SerializeField]
        SceneTransitionGameEvent OnFinishUnloadScene;

        public void RegisterHandler(ISceneLoadHandler handler) {
            sceneLoadHandlers.Add(handler);
        }

        public void UnregisterHandler(ISceneLoadHandler handler) {
            sceneLoadHandlers.Remove(handler);
        }

        public async void UpdateScene(SceneTransition transition) {
            for (int i = 0; i < sceneLoadHandlers.Count; i++) {
                await sceneLoadHandlers[i].OnLoadSceneStarted();
            }

            OnStartUnloadScene.Raise(transition);
            await SceneManager.UnloadSceneAsync(transition.UnloadScene.sceneIndex, UnloadSceneOptions.None);
            OnFinishUnloadScene.Raise(transition);

            await transition.UnloadScene.Finalize();
            await transition.LoadScene.Initialize();

            OnStartLoadScene.Raise(transition);
            await SceneManager.LoadSceneAsync(transition.LoadScene.sceneIndex, LoadSceneMode.Additive);
            OnFinishLoadScene.Raise(transition);

            for (int i = sceneLoadHandlers.Count - 1; i >= 0; i--) {
                await sceneLoadHandlers[i].OnLoadSceneFinished();
            }
        }

    }
}