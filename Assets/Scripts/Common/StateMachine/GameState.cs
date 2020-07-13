using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/State/GameState")]
    public class GameState : ScriptableObject {
        public GameEvent OnEnter;
        public GameEvent OnExit;
    }
}
