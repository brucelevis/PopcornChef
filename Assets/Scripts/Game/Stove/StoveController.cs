using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Game/Stove/StoveController")]
    public class StoveController : ScriptableObject {

        public StovePower power;

        [SerializeField]
        StovePowerGameEvent OnChange;

        public void SetPower(StovePower power) {
            this.power = power;
            OnChange.Raise(power);
        }

    }
}
