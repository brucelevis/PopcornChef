using UnityEngine;

namespace PopcornChef.Game {
    public class SafeMoveSimulator : MoveSimulator {

        [SerializeField]
        PenetrationResolver _penetrationResolver;

        [SerializeField]
        PolygonCollider2D targetCollider;

        [SerializeField]
        int penetrationLayer;

        public override void Pickup() {
            base.Pickup();
        }

        public override async void Place() {
            var resolvePenetrationSetting = new PenetrationResolveSetting {
                targetCollider = targetCollider,
                internalObjectParent = dummyParent,
                position = dummyObject.transform.position,
                rotation = dummyObject.transform.rotation,
                scale = dummyObject.transform.localScale,
                layer = penetrationLayer,
            };
            var result = await _penetrationResolver.ResolvePenetration(resolvePenetrationSetting);

            if (result.isSucceed) {
                base.Place(result.position, result.rotation);
            } else {
                base.CancelMove();
            }
        }

    }
}
