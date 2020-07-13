using UnityEngine;

namespace PopcornChef.Game {
    public class ImpactReceiver : MonoBehaviour {

        public Rigidbody2D target;
        public Vector2UnityEvent OnReceive;

        public void Impact(Vector2 force) {
            target.AddForce(force, ForceMode2D.Impulse);
            OnReceive.Invoke(force);
        }

    }
}
