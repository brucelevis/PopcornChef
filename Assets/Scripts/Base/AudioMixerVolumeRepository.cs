using UnityEngine;
using UnityEngine.Audio;

namespace PopcornChef.Base {
    [CreateAssetMenu(menuName = "PopcornChef/Audio/AudioMixerVolumeRepository")]
    public class AudioMixerVolumeRepository : ScriptableObject {

        [SerializeField]
        string bgmVolumeKey = "BGMVolume";

        [SerializeField]
        string seVolumeKey = "SEVolume";

        [SerializeField]
        float defaultBGMVolume = 0.7f;

        [SerializeField]
        float defaultSEVolume = 0.7f;

        public float GetBGMVolume() {
            return PlayerPrefs.GetFloat(bgmVolumeKey, defaultBGMVolume);
        }

        public float GetSEVolume() {
            return PlayerPrefs.GetFloat(seVolumeKey, defaultSEVolume);
        }

        public void SetBGMVolume(float volume) {
            PlayerPrefs.SetFloat(bgmVolumeKey, volume);
        }

        public void SetSEVolume(float volume) {
            PlayerPrefs.SetFloat(seVolumeKey, volume);
        }

    }
}
