using UnityEngine;

namespace PopcornChef {
    public class FloatGameEventListener : GameEventListener<float, FloatUnityEvent> {

        public FloatGameEvent Event;

        void OnEnable() {
            Event.RegisterListener(this);
        }

        void OnDisable() {
            Event.UnregisterListener(this);
        }

    }
}
