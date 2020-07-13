using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;

namespace PopcornChef.Game {
    public class ImpactSource : MonoBehaviour {

        struct ReceiverComponent {
            public ImpactReceiver receiver;
            public Collider2D collider;
        }

        struct WallComponent {
            public ImpactWall wall;
            public Collider2D collider;
        }

        public Collider2D areaCollider;
        public Collider2D sourceCollider;
        List<ImpactReceiver> ignoreReceivers = new List<ImpactReceiver>();

        public float power;

        void Start() {
            areaCollider.OnTriggerEnter2DAsObservable().Subscribe(AffectImpact).AddTo(this);
        }

        public void RegistIgnoreReceiver(ImpactReceiver receiver) {
            ignoreReceivers.Add(receiver);
        }

        public void UnregistIgnoreReceiver(ImpactReceiver receiver) {
            ignoreReceivers.Remove(receiver);
        }

        void AffectImpact(Collider2D other) {
            var receiver = other.GetComponentInParent<ImpactReceiver>();
            if (receiver == null || ignoreReceivers.IndexOf(receiver) >= 0) return;
            var impactForce = CalculateForce(
                new ReceiverComponent {
                    receiver = receiver,
                    collider = other
                },
                GetWall(other.gameObject)
            );
            receiver.Impact(impactForce);
        }

        IEnumerable<WallComponent> GetWall(GameObject other) {
            Vector2 vectorBetweenObjects = (other.transform.position - transform.position);
            float distance = vectorBetweenObjects.magnitude;

            var hits = Physics2D.RaycastAll(
                transform.position,
                vectorBetweenObjects,
                distance
            );

            return hits
                .Select(x => new WallComponent {
                    wall = x.transform.gameObject.GetComponentInParent<ImpactWall>(),
                    collider = x.collider
                })
                .Where(x => x.wall != null);
        }

        Vector2 CalculateForce(
            ReceiverComponent receiver,
            IEnumerable<WallComponent> walls
        ) {
            var colliderDistance = sourceCollider.Distance(receiver.collider);
            Vector2 direction = colliderDistance.normal;
            float distance = Mathf.Max(0.5f, colliderDistance.distance);
            float totalDiffence = Mathf.Max(1f, walls.Aggregate(1f, (x, comp) => x * comp.wall.diffence));
            float impactMagnitude = power / (distance * totalDiffence);
            return impactMagnitude * direction;
        }

    }
}
