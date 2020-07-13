using UnityEngine;
using UniRx.Triggers;
using UnityEngine.Events;
using UniRx;
using Cysharp.Threading.Tasks;

namespace PopcornChef {
    public class AnimatorSwitch : MonoBehaviour {

        [SerializeField]
        Animator _animator;

        public string boolAnimatorPropertyName;
        public string setStateName;
        public string resetStateName;
        public UnityEvent OnSetStarted;
        public UnityEvent OnSetFinished;
        public UnityEvent OnResetStarted;
        public UnityEvent OnResetFinished;

        ObservableStateMachineTrigger stateMachineTrigger;

        void Start() {
            stateMachineTrigger = _animator.GetBehaviour<ObservableStateMachineTrigger>();
        }

        public void SetSwitchAndForget(bool value) {
            SetSwitch(value).Forget();
        }

        public async UniTask SetSwitch(bool value) {
            _animator.SetBool(boolAnimatorPropertyName, value);

            var startEvent = value ? OnSetStarted : OnResetStarted;
            var finsihEvent = value ? OnSetFinished : OnResetFinished;
            var stateName = value ? setStateName : resetStateName;

            startEvent.Invoke();
            await UniTask.WaitUntil(() => stateMachineTrigger != null);
            await stateMachineTrigger.OnStateEnterAsObservable()
                .Where(x => x.StateInfo.IsName(stateName))
                .First();
            finsihEvent.Invoke();
        }

    }
}
