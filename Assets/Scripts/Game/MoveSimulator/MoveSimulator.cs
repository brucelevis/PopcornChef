using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef.Game {
    public class MoveSimulator : MonoBehaviour {

        public Rigidbody2D targetRigidbody;
        public SpriteRenderer targetRenderer;
        public Transform dummyParent;
        public float dummyDepth;
        public Color dummyColor;
        public UnityEvent OnPickup;
        public UnityEvent OnPlace;
        public UnityEvent OnCancelMove;

        protected GameObject dummyObject = null;
        protected bool isMoving = false;
        protected Vector2 moveStartPosition = Vector2.zero;

        public virtual void Pickup() {
            if (isMoving) return;
            Debug.Log("pickup");
            isMoving = true;
            EnableDummy();
            OnPickup.Invoke();
        }

        public virtual void Place() {
            if (!isMoving) return;
            Debug.Log("place");
            isMoving = false;
            ApplyMovement();
            DisableDummy();
            OnPlace.Invoke();
        }

        public virtual void Place(Vector2 position, float rotation) {
            if (!isMoving) return;
            Debug.Log("place");
            isMoving = false;
            ApplyMovement(position, rotation);
            DisableDummy();
            OnPlace.Invoke();
        }

        public virtual void CancelMove() {
            Debug.Log("cancel");
            if (!isMoving) return;
            isMoving = false;
            DisableDummy();
            OnCancelMove.Invoke();
        }

        void EnableDummy() {
            dummyObject = new GameObject($"{name}(Dummy)");
            dummyObject.transform.SetParent(dummyParent);

            var renderer = dummyObject.AddComponent(targetRenderer);
            renderer.sortingLayerID = targetRenderer.sortingLayerID;
            renderer.sortingOrder = targetRenderer.sortingOrder;

            dummyObject.transform.localScale = transform.localScale;
            dummyObject.transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, dummyDepth), transform.rotation);
            targetRenderer.color = new Color(1f, 1f, 1f, 0.5f);
        }

        void DisableDummy() {
            targetRenderer.color = new Color(1f, 1f, 1f, 1f);
            Destroy(dummyObject);
        }

        void ApplyMovement() {
            targetRigidbody.velocity = Vector2.zero;
            targetRigidbody.angularVelocity = 0;
            targetRigidbody.position = dummyObject.transform.position;
            targetRigidbody.SetRotation(dummyObject.transform.rotation);
        }

        void ApplyMovement(Vector2 position, float rotation) {
            targetRigidbody.velocity = Vector2.zero;
            targetRigidbody.angularVelocity = 0;
            targetRigidbody.position = position;
            targetRigidbody.SetRotation(rotation);
        }

        public void MoveTo(Vector2 pos) {
            if (!isMoving) return;
            dummyObject.transform.position = new Vector3(pos.x, pos.y, dummyDepth);
        }

    }
}
