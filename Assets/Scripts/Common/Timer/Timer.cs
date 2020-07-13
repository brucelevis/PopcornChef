using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class Timer : MonoBehaviour {

        public float TickTime;
        public bool ResetOnTick = true;
        public UnityEvent OnTick;
        float leftTime;

        public void Start() {
            Reset();
        }

        public void Reset() {
            leftTime = TickTime;
        }

        void Update() {
            if (leftTime == 0f) return;
            leftTime = Mathf.Max(0f, leftTime - Time.deltaTime);
            if (leftTime == 0f) {
                OnTick.Invoke();
                if (ResetOnTick) Reset();
            }
        }

    }
}