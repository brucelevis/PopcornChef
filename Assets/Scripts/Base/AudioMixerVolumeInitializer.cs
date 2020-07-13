using UnityEngine;

namespace PopcornChef.Base {
    public class AudioMixerVolumeInitializer : MonoBehaviour {

        [SerializeField]
        AudioMixerVolumeRepository repository;

        [SerializeField]
        AudioMixerVolume audioMixerVolume;

        void Start() {
            audioMixerVolume.SetBGMVolume(repository.GetBGMVolume());
            audioMixerVolume.SetSEVolume(repository.GetSEVolume());
        }

    }
}
