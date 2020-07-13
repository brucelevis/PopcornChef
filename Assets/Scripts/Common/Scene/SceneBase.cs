using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PopcornChef {
    public abstract class SceneBase : ScriptableObject {

        public int sceneIndex;
        public GameStateMachine stateMachine;

        public async UniTask Initialize() {
            await BeforeLoadScene();
            if (stateMachine != null) {
                stateMachine.InitializeStateMachine();
            }
        }

        public async UniTask Finalize() {
            if (stateMachine != null) {
                stateMachine.FinalizeStateMachine();
            }
            await AfterUnloadScene();
        }

        public abstract UniTask AfterUnloadScene();
        public abstract UniTask BeforeLoadScene();

    }
}