using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class FrameTimer : MonoBehaviour {

        public int TickFrame;
        public bool ResetOnTick = true;
        public UnityEvent OnTick;
        int leftFrame;

        void Start() {
            Reset();
        }

        void Reset() {
            leftFrame = TickFrame;
        }

        void Update() {
            if (leftFrame == 0) return;
            leftFrame--;
            if (leftFrame == 0) {
                OnTick.Invoke();
                if (ResetOnTick) Reset();
            }
        }

    }
}