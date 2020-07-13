using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef.Game {
    public class HeatTriggerPoint : MonoBehaviour {

        [SerializeField]
        Heat _heat;

        public float trigger;
        public UnityEvent OnReached;
        public FloatUnityEvent OnProgressChanged;

        void Start() {
            _heat.OnHeatChanged.AddListener(ApplyProgressChange);
        }

        void OnDestroy() {
            _heat.OnHeatChanged.RemoveListener(ApplyProgressChange);
        }

        void ApplyProgressChange(float heat) {
            OnProgressChanged.Invoke(Mathf.Clamp(heat / trigger, 0f, 1f));
            if (heat >= trigger) OnReached.Invoke();
        }

    }
}
