using UnityEngine;

namespace PopcornChef.Game {
    public class StovePowerGameEventListener : GameEventListener<StovePower, StovePowerUnityEvent> {

        public StovePowerGameEvent Event;

        void OnEnable() {
            Event.RegisterListener(this);
        }

        void OnDisable() {
            Event.UnregisterListener(this);
        }

    }
}
