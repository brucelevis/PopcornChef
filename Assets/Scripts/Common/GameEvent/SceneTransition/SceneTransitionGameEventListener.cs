using UnityEngine;

namespace PopcornChef {
    public class SceneTransitionGameEventListener : GameEventListener<SceneTransition, SceneTransitionUnityEvent> {

        public SceneTransitionGameEvent Event;

        void OnEnable() {
            Event.RegisterListener(this);
        }

        void OnDisable() {
            Event.UnregisterListener(this);
        }

    }
}
