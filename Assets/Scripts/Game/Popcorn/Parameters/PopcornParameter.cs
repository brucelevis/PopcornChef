using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Game/Popcorn/Parameter/Base")]
    public class PopcornParameter : ScriptableObject {
        public float popHeat;
        public float burnHeat;
        public float eatScore;
        public float explosionPower;
        public float unpoppedImpactDiffence;
        public float poppedImpactDiffence;
        public float unpoppedMass;
        public float poppedMass;
    }
}
