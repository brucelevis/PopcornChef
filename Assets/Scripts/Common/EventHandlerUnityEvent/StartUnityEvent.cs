using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class StartUnityEvent : MonoBehaviour {

        public UnityEvent start;

        void Start() {
            start.Invoke();
        }

    }
}
