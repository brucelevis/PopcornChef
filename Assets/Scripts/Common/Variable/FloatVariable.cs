using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "Variable/float")]
    public class FloatVariable : ScriptableObject {

        public float Min;
        public float Max;
        public float Initial;
        float value;
        public float Value {
            get {
                return value;
            }
            set {
                float previous = this.value;
                this.value = Mathf.Clamp(value, Min, Max);
                if (previous == this.value) return;
                OnValueChanged.Raise(this.value);
            }
        }
        public FloatGameEvent OnValueChanged;

        public void Initialize() {
            Value = Initial;
        }

    }
}
