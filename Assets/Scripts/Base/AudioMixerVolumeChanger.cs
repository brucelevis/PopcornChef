using UnityEngine;
using UnityEngine.Audio;

namespace PopcornChef.Base {
    [CreateAssetMenu(menuName = "PopcornChef/Audio/AudioMixerVolumeChanger")]
    public class AudioMixerVolumeChanger : ScriptableObject {

        [SerializeField]
        AudioMixer audioMixer;

        [SerializeField]
        string bgmVolumePropertyName;

        [SerializeField]
        string seVolumePropertyName;

        [SerializeField]
        float muteVolumeScale = -80f;

        [SerializeField]
        float minVolumeScale = -60f;

        [SerializeField]
        float maxVolumeScale = 0f;

        // 0f <= volume <= 1f
        public void SetBGMVolume(float volume) {
            audioMixer.SetFloat(bgmVolumePropertyName, ConvertToVolumeScale(volume));
        }

        public void SetSEVolume(float volume) {
            audioMixer.SetFloat(seVolumePropertyName, ConvertToVolumeScale(volume));
        }

        float ConvertToVolumeScale(float volume) {
            if (volume == 0f) return muteVolumeScale;
            return minVolumeScale + ((maxVolumeScale - minVolumeScale) * volume);
        }

    }
}
