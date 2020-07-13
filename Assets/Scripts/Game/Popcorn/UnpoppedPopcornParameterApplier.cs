using UnityEngine;
using UniRx;

namespace PopcornChef.Game {
    /// <summary>
    ///   破裂前のポップコーンに設定パラメータを適用する
    /// </summary>
    public class UnpoppedPopcornParameterApplier : BasePopcornParameterApplier {

        [SerializeField]
        PopcornParameter parameter;

        [SerializeField]
        Transform _transform;

        [SerializeField]
        HeatTriggerPoint popHeatTriggerPoint;

        [SerializeField]
        Rigidbody2D _rigidbody;

        [SerializeField]
        ImpactWall impactWall;

        [SerializeField]
        ExplosionGenerator explosionGenerator;

        public virtual void Start() {
            parameter.ObserveEveryValueChanged(x => x.popHeat).Subscribe(_ => ApplyPopHeat()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.unpoppedMass).Subscribe(_ => ApplyMass()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.unpoppedImpactDiffence).Subscribe(_ => ApplyImpactDiffence()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.explosionPower).Subscribe(_ => ApplyExplosionPower()).AddTo(this);
            seed.Subscribe(_ => {
                ApplyScale();
                ApplyPopHeat();
                ApplyMass();
                ApplyImpactDiffence();
                ApplyExplosionPower();
            }).AddTo(this);
        }

        public void ApplyScale() {
            _transform.localScale = Vector2.one * seed.Value;
        }

        public void ApplyPopHeat() {
            if (popHeatTriggerPoint == null) return;
            popHeatTriggerPoint.trigger = parameter.popHeat * seed.Value;
        }

        public void ApplyMass() {
            if (_rigidbody == null) return;
            _rigidbody.mass = parameter.unpoppedMass * seed.Value;
        }

        public void ApplyImpactDiffence() {
            if (impactWall == null) return;
            impactWall.diffence = parameter.unpoppedImpactDiffence * seed.Value;
        }

        public void ApplyExplosionPower() {
            if (explosionGenerator == null) return;
            explosionGenerator.explosionPower = parameter.explosionPower * seed.Value;
        }

    }
}
