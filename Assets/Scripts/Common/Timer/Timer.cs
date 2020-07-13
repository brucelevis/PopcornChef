using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class Timer : MonoBehaviour {

        public float TickTime;
        public UnityEvent OnTick;
        float leftTime;

        void Start() {
            leftTime = TickTime;
        }

        void Update() {
            leftTime -= Time.deltaTime;
            if (leftTime <= 0f) {
                OnTick.Invoke();
                leftTime = TickTime;
            }
        }

    }
}