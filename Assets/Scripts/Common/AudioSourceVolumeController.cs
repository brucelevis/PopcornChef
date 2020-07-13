using UnityEngine;

namespace PopcornChef.Game {
    public class AudioSourceVolumeController : MonoBehaviour {

        [SerializeField]
        AudioSource _audioSource;

        public ParticleSystem.MinMaxCurve volume;

        public void SetVolumeByRate(float rate) {
            _audioSource.volume = volume.Evaluate(rate);
        }

    }
}
