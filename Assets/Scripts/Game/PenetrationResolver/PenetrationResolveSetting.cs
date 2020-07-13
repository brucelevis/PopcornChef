using UnityEngine;

namespace PopcornChef.Game {
    public struct PenetrationResolveSetting {
        public PolygonCollider2D targetCollider;
        public Transform internalObjectParent;
        public Vector2 position;
        public Quaternion rotation;
        public Vector2 scale;
        public int layer;
    }
}
