using UnityEngine.Events;
using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu]
    public class Hand : ScriptableObject {

        const float minValue = 0f;
        const float maxValue = 1f;

        [Tooltip("手の耐久力")]
        [SerializeField, Range(minValue, maxValue)]
        public float Durability;

        [Tooltip("掴んでいるポップコーンのGameObject")]
        public GameObject HoldingPopcorn;

        public UnityEvent OnHold = new UnityEvent();
        public UnityEvent OnPlace = new UnityEvent();
        public UnityEvent OnCancel = new UnityEvent();

        public void Hold(GameObject popcorn) {
            OnHold.Invoke();
        }

        public void Place() {
            OnPlace.Invoke();
        }

        public void Cancel() {
            OnCancel.Invoke();
        }

    }
}
