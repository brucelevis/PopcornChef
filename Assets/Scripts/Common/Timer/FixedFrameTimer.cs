using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class FixedFrameTimer : MonoBehaviour {

        public int TickFrame;
        public bool ResetOnTick = true;
        public UnityEvent OnTick;
        int leftFrame;

        public void Start() {
            Reset();
        }

        public void Reset() {
            leftFrame = TickFrame;
        }

        void FixedUpdate() {
            if (leftFrame == 0) return;
            leftFrame--;
            if (leftFrame == 0) {
                OnTick.Invoke();
                if (ResetOnTick) Reset();
            }
        }

    }
}