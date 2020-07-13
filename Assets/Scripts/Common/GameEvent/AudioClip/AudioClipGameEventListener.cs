using UnityEngine;

namespace PopcornChef {
    public class AudioClipGameEventListener : GameEventListener<AudioClip, AudioClipUnityEvent> {

        public AudioClipGameEvent Event;

        void OnEnable() {
            Event.RegisterListener(this);
        }

        void OnDisable() {
            Event.UnregisterListener(this);
        }

    }
}
