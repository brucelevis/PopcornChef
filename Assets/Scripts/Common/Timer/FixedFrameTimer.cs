using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class FixedFrameTimer : MonoBehaviour {

        public int TickFrame;
        public UnityEvent OnTick;
        int leftFrame;

        void Start() {
            leftFrame = TickFrame;
        }

        void FixedUpdate() {
            leftFrame--;
            if (leftFrame <= 0) {
                OnTick.Invoke();
                leftFrame = TickFrame;
            }
        }

    }
}