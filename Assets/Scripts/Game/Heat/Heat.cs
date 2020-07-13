using UnityEngine;

namespace PopcornChef.Game {
    public class Heat : MonoBehaviour {

        public float heat = 0;
        public FloatUnityEvent OnHeatChanged;

        public void Add(float heat) {
            this.heat += heat;
            OnHeatChanged.Invoke(this.heat);
        }

    }
}
