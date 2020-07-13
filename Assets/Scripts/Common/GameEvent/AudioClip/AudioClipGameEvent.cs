using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Event/AudioClipGameEvent")]
    public class AudioClipGameEvent : GameEvent<AudioClip, AudioClipUnityEvent> {}
}
