using UnityEngine;
using System.Collections.Generic;

namespace PopcornChef.Game {
    /// <summary>
    ///   爆発オブジェクトを生成する
    /// </summary>
    public class ExplosionGenerator : MonoBehaviour {

        public List<ImpactReceiver> ignoreReceivers;
        public ImpactSource explosionPrefab;
        public float explosionPower;

        public void Explode() {
            var explosionImpactSource = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation,
                transform.parent
            );
            foreach (var receiver in ignoreReceivers) {
                explosionImpactSource.RegistIgnoreReceiver(receiver);
            }
            explosionImpactSource.power = explosionPower;
        }

    }
}
