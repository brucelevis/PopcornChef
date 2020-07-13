using UnityEngine;
using UniRx;

namespace PopcornChef.Game {
    /// <summary>
    ///   破裂前のポップコーン(Blaze)に設定パラメータを適用する
    /// </summary>
    public class UnpoppedBlazePopcornParameterApplier : UnpoppedPopcornParameterApplier {

        [SerializeField]
        BlazePopcornParameter blazeParameter;

        [SerializeField]
        HeatBrustGenerator heatBrustGenerator;

        public override void Start() {
            base.Start();
            blazeParameter.ObserveEveryValueChanged(x => x.brustHeat).Subscribe(_ => ApplyBrustPower()).AddTo(this);
            seed.Subscribe(_ => {
                ApplyBrustPower();
            }).AddTo(this);
        }

        public void ApplyBrustPower() {
            if (heatBrustGenerator == null) return;
            heatBrustGenerator.brustHeat = blazeParameter.brustHeat * seed.Value;
        }

    }
}
