using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class GameEventListener : MonoBehaviour {

        public GameEvent Event;
        public UnityEvent Response;
        bool hasRegisteredOnce = false;

        void OnEnable() {
            if (!hasRegisteredOnce) return;
            Event.RegisterListener(this);
        }

        void Start() {
            Event.RegisterListener(this);
            hasRegisteredOnce = true;
        }

        void OnDisable() {
            Event.UnregisterListener(this);
        }

        public void OnEventRaised() {
            Response.Invoke();
        }

    }
}
