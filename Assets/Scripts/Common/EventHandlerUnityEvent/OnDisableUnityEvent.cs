using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class OnDisableUnityEvent : MonoBehaviour {

        public UnityEvent onDisable;

        void OnDisable() {
            onDisable.Invoke();
        }

    }
}
