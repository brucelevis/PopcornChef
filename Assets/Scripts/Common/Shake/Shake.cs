using UnityEngine;

namespace PopcornChef.Game {
    public class Shake : MonoBehaviour {

        [SerializeField]
        Rigidbody2D _rigidbody;

        [Min(0f)]
        public float power = 0f;

        [Range(0f, 1f)]
        public float chance = 0f;

        void FixedUpdate() {
            Simulate(power);
        }

        void Simulate(float power) {
            if (power <= 0 || UnityEngine.Random.Range(0f, 1f) >= chance) return;
            _rigidbody.AddForceAtPosition(
                _rigidbody.mass * new Vector2(0, UnityEngine.Random.Range(-power, 0f)),
                (Vector2)transform.position + Vector2.Scale(transform.localScale, new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f))),
                ForceMode2D.Impulse
            );
        }

        public void SetPower(float power) {
            this.power = Mathf.Max(0f, power);
        }

        public void SetChance(float chance) {
            this.chance = Mathf.Clamp(chance, 0f, 1f);
        }

    }
}
