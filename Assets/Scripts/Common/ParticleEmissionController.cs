using UnityEngine;

namespace PopcornChef.Game {
    public class ParticleEmissionController : MonoBehaviour {

        [SerializeField]
        ParticleSystem _particleSystem;

        public ParticleSystem.MinMaxCurve emission;

        public void SetEmissionByRate(float rate) {
            var e = _particleSystem.emission;
            e.rateOverTimeMultiplier = emission.Evaluate(rate);
        }

    }
}
