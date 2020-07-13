using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class OnEnableUnityEvent : MonoBehaviour {

        public UnityEvent onEnable;

        void OnEnable() {
            onEnable.Invoke();
        }

    }
}
