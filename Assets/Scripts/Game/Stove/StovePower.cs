using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Game/Stove/StovePower")]
    public class StovePower : ScriptableObject {
        public float heatPerSecond;
    }
}
