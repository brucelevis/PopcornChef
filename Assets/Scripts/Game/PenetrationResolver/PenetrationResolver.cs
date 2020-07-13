using UnityEngine;
using Cysharp.Threading.Tasks;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Simulation/PenetrationResolver")]
    public class PenetrationResolver : ScriptableObject {

        public float fixMargin = 0.1f;
        public int broadResolveFrame = 3;
        public int narrowResolveFrame = 2;

        Rigidbody2D GenerateSimulateObject(PenetrationResolveSetting setting) {
            var simulateObject = new GameObject(setting.targetCollider.name + "(Penetration)");
            simulateObject.transform.SetParent(setting.internalObjectParent);
            simulateObject.transform.localScale = setting.scale;
            simulateObject.layer = setting.layer;

            var simulateRigidbody = simulateObject.AddComponent<Rigidbody2D>();
            simulateRigidbody.position = setting.position;
            simulateRigidbody.SetRotation(setting.rotation);
            simulateRigidbody.bodyType = RigidbodyType2D.Dynamic;
            simulateRigidbody.gravityScale = 0f;
            simulateRigidbody.mass = 0f;
            simulateRigidbody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

            var simulateCollider = simulateRigidbody.gameObject.AddComponent(setting.targetCollider);
            simulateCollider.isTrigger = false;

            return simulateRigidbody;
        }

        public async UniTask<PenetrationResolveResult> ResolvePenetration(PenetrationResolveSetting setting) {
            var simulateRigidbody = GenerateSimulateObject(setting);
            var beforePosition = simulateRigidbody.position;

            await UniTask.DelayFrame(broadResolveFrame, PlayerLoopTiming.FixedUpdate);

            var fixedMoveVector = simulateRigidbody.position - beforePosition;
            simulateRigidbody.position += new Vector2(
                (fixedMoveVector.x < 0f) ? -fixMargin : ((fixedMoveVector.x > 0f) ? fixMargin : 0f),
                (fixedMoveVector.y < 0f) ? -fixMargin : ((fixedMoveVector.y > 0f) ? fixMargin : 0f)
            );

            await UniTask.DelayFrame(narrowResolveFrame, PlayerLoopTiming.FixedUpdate);
            bool isTouching = simulateRigidbody.IsTouchingLayers(1 << setting.layer);

            PenetrationResolveResult result;
            if (isTouching) {
                result = PenetrationResolveResult.Failed;
            } else {
                result = PenetrationResolveResult.Succeed(simulateRigidbody.position, simulateRigidbody.rotation);
            }

            GameObject.Destroy(simulateRigidbody.gameObject);
            return result;
        }

    }
}
