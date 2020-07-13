using UnityEngine;

namespace PopcornChef.Game {
    public class ShakeController : MonoBehaviour {

        [SerializeField]
        Shake _shake;

        public ParticleSystem.MinMaxCurve power;
        public ParticleSystem.MinMaxCurve chance;

        public void SetShakeByRate(float rate) {
            _shake.SetPower(power.Evaluate(rate));
            _shake.SetChance(chance.Evaluate(rate));
        }

    }
}
