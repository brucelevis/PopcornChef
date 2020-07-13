using UnityEngine;

namespace PopcornChef {
    public class UICursorTracker : MonoBehaviour {

        public RectTransform canvas;
        public Vector2 offset;

        public void Update() {
            Vector2 mousePosition = Input.mousePosition;
            Vector2 localpoint = new Vector2(
                ((mousePosition.x * canvas.sizeDelta.x / Screen.width) - (canvas.sizeDelta.x * 0.5f)),
                ((mousePosition.y * canvas.sizeDelta.y / Screen.height) - (canvas.sizeDelta.y * 0.5f))
            );
            transform.localPosition = localpoint + offset;
        }

    }
}
