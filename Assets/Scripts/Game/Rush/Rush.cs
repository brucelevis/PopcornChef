using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef.Game.Rush {
    [CreateAssetMenu]
    public class Rush : ScriptableObject {
        public string message;
        public UnityEvent OnOccur = new UnityEvent();
    }
}
