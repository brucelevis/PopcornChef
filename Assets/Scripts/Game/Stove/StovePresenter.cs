using UnityEngine;

namespace PopcornChef.Game {
    public class StovePresenter : MonoBehaviour {

        [Header("火の粉のパーティクル")]
        [SerializeField]
        ParticleSystem fireParticle;
        public ParticleSystem.MinMaxCurve emissionRateByPower;

        [Header("バーナーのSE")]
        [SerializeField]
        AudioSource burningAudioSource;
        public ParticleSystem.MinMaxCurve volumeByPower;

        public void SetPresentation(StovePower power) {
            SetFireParticleEmission(power.heatPerSecond);
            SetBurningSoundVolume(power.heatPerSecond);
        }

        void SetFireParticleEmission(float power) {
            var e = fireParticle.emission;
            e.rateOverTime = emissionRateByPower.Evaluate(power);
        }

        void SetBurningSoundVolume(float power) {
            burningAudioSource.volume = power;
        }

    }
}
