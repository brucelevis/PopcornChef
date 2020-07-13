using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UniRx.Triggers;

namespace PopcornChef.Game {
    public class HeatSource : MonoBehaviour {

        struct ReceiverComponent {
            public HeatReceiver receiver;
            public Collider2D collider;
        }

        public Collider2D areaCollider;
        public Collider2D sourceCollider;
        List<HeatReceiver> ignoreReceivers = new List<HeatReceiver>();

        public float power;

        void Start() {
            areaCollider.OnTriggerStay2DAsObservable().Subscribe(AffectHeat).AddTo(this);
        }

        public void RegistIgnoreReceiver(HeatReceiver receiver) {
            ignoreReceivers.Add(receiver);
        }

        public void UnregistIgnoreReceiver(HeatReceiver receiver) {
            ignoreReceivers.Remove(receiver);
        }

        void AffectHeat(Collider2D other) {
            var receiver = other.GetComponentInParent<HeatReceiver>();
            if (receiver == null || ignoreReceivers.IndexOf(receiver) >= 0) return;
            float heat = CalculateHeat(new ReceiverComponent {
                receiver = receiver,
                collider = other
            });
            receiver.Heat(heat);
        }

        float CalculateHeat(ReceiverComponent receiver) {
            var colliderDistance = sourceCollider.Distance(receiver.collider);
            float distance = Mathf.Max(0.5f, colliderDistance.distance);
            return power * Time.deltaTime / distance;
        }

    }
}
