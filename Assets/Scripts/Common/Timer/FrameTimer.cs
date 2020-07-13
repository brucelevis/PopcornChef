using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class FrameTimer : MonoBehaviour {

        public int TickFrame;
        public UnityEvent OnTick;
        int leftFrame;

        void Start() {
            leftFrame = TickFrame;
        }

        void Update() {
            leftFrame--;
            if (leftFrame <= 0) {
                OnTick.Invoke();
                leftFrame = TickFrame;
            }
        }

    }
}