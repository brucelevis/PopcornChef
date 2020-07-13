using UnityEngine;

namespace PopcornChef.Game {
    public struct PenetrationResolveResult {
        public readonly bool isSucceed;
        public readonly Vector2 position;
        public readonly float rotation;
        public static PenetrationResolveResult Failed => new PenetrationResolveResult(false, Vector2.zero, 0f);
        public static PenetrationResolveResult Succeed(Vector2 position, float rotation)
            => new PenetrationResolveResult(true, position, rotation);

        PenetrationResolveResult(bool isSucceed, Vector2 position, float rotation) {
            this.isSucceed = isSucceed;
            this.position = position;
            this.rotation = rotation;
        }
    }
}
