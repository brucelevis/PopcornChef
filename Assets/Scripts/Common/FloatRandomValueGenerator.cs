using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "RandomValue/float")]
    public class FloatRandomValueGenerator : ScriptableObject {
        public float Max;
        public float Min;

        public float GetRandomValue() {
            return Random.Range(Min, Max);
        }
    }
}
