using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;

namespace PopcornChef.Base {
    public class Curtain : MonoBehaviour, ISceneLoadHandler {

        [SerializeField]
        SceneUpdater sceneUpdater;

        [SerializeField]
        Animator _animator;

        [SerializeField]
        string switchPropertyName;

        [SerializeField]
        string openStateName;

        [SerializeField]
        string closeStateName;

        ObservableStateMachineTrigger stateMachineTrigger;

        void OnEnable() {
            sceneUpdater.RegisterHandler(this);
        }

        void OnDisable() {
            sceneUpdater.UnregisterHandler(this);
        }

        void Start() {
            stateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
        }

        public async UniTask OnLoadSceneFinished() {
            _animator.SetBool(switchPropertyName, true);
            await stateMachineTrigger.OnStateEnterAsObservable()
                .Where(x => x.StateInfo.IsName(openStateName))
                .First();
        }

        public async UniTask OnLoadSceneStarted() {
            _animator.SetBool(switchPropertyName, false);
            await stateMachineTrigger.OnStateEnterAsObservable()
                .Where(x => x.StateInfo.IsName(closeStateName))
                .First();
        }

    }
}