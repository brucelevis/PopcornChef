using UnityEngine;

namespace PopcornChef {
    public class CursorUnityEvent : MonoBehaviour {

        public Vector2UnityEvent OnUpdate;

        void Update() {
            var position = Camera.main.ScreenToWorldPoint(Vector3.Scale(Input.mousePosition, new Vector3(1, 1, 0)));
            OnUpdate.Invoke(position);
        }

    }
}
