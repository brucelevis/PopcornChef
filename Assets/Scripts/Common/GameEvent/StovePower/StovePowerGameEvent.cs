using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Event/StovePowerGameEvent")]
    public class StovePowerGameEvent : GameEvent<StovePower, StovePowerUnityEvent> {}
}
