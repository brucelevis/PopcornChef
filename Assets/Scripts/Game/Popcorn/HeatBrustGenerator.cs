using UnityEngine;
using System.Collections.Generic;

namespace PopcornChef.Game {
    /// <summary>
    ///   熱放射オブジェクトを生成する
    /// </summary>
    public class HeatBrustGenerator : MonoBehaviour {

        public List<HeatReceiver> ignoreReceivers;
        public HeatSource explosionPrefab;
        public float brustHeat;

        public void HeatBrust() {
            var brustHeatSource = Instantiate(
                explosionPrefab,
                transform.position,
                transform.rotation,
                transform.parent
            );
            foreach (var receiver in ignoreReceivers) {
                brustHeatSource.RegistIgnoreReceiver(receiver);
            }
            brustHeatSource.power = brustHeat;
        }

    }
}
