using UnityEngine;

namespace PopcornChef.Game {
    public class HeatReceiver : MonoBehaviour {

        public Heat target;
        public FloatUnityEvent OnReceive;

        public void Heat(float heat) {
            target.Add(heat);
            OnReceive.Invoke(heat);
        }

    }
}
