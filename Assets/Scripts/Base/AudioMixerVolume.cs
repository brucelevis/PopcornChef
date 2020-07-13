using UnityEngine;

namespace PopcornChef.Base {
    [CreateAssetMenu(menuName = "PopcornChef/Audio/AudioMixerVolume")]
    public class AudioMixerVolume : ScriptableObject {

        [SerializeField]
        FloatGameEvent UpdateBGMEvent;

        [SerializeField]
        FloatGameEvent UpdateSEEvent;

        // 0f <= volume <= 1f
        public void SetBGMVolume(float volume) {
            UpdateBGMEvent.Raise(volume);
        }

        public void SetSEVolume(float volume) {
            UpdateSEEvent.Raise(volume);
        }

    }
}
