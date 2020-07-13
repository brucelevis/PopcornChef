using UnityEngine;
using UniRx;

namespace PopcornChef.Game {
    /// <summary>
    ///   破裂後のポップコーンに設定パラメータを適用する
    /// </summary>
    public class PoppedPopcornParameterApplier : BasePopcornParameterApplier {

        [SerializeField]
        PopcornParameter parameter;

        [SerializeField]
        Transform _transform;

        [SerializeField]
        HeatTriggerPoint burnHeatTriggerPoint;

        [SerializeField]
        Rigidbody2D _rigidbody;

        [SerializeField]
        ImpactWall impactWall;

        [SerializeField]
        PopcornScoreApplier scoreApplier;

        void Start() {
            parameter.ObserveEveryValueChanged(x => x.burnHeat).Subscribe(_ => ApplyBurnHeat()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.poppedMass).Subscribe(_ => ApplyMass()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.poppedImpactDiffence).Subscribe(_ => ApplyImpactDiffence()).AddTo(this);
            parameter.ObserveEveryValueChanged(x => x.eatScore).Subscribe(_ => ApplyScore()).AddTo(this);
            seed.Subscribe(_ => {
                ApplyScale();
                ApplyBurnHeat();
                ApplyMass();
                ApplyImpactDiffence();
                ApplyScore();
            }).AddTo(this);
        }

        public void ApplyScale() {
            _transform.localScale = Vector2.one * seed.Value;
        }

        public void ApplyBurnHeat() {
            if (burnHeatTriggerPoint == null) return;
            burnHeatTriggerPoint.trigger = parameter.burnHeat * seed.Value;
        }

        public void ApplyMass() {
            if (_rigidbody == null) return;
            _rigidbody.mass = parameter.poppedMass * seed.Value;
        }

        public void ApplyImpactDiffence() {
            if (impactWall == null) return;
            impactWall.diffence = parameter.poppedImpactDiffence * seed.Value;
        }

        public void ApplyScore() {
            if (scoreApplier == null) return;
            scoreApplier.score = parameter.eatScore * seed.Value;
        }

    }
}
