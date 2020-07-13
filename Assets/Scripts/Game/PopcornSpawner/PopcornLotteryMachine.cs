using System.Linq;
using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Game/PopcornLotteryMachine")]
    public class PopcornLotteryMachine : LotteryMachine<BasePopcornParameterApplier, PopcornLotteryItem> {

        public override void UpdateItems(int[] selected) {
            for (int i = 0; i < selected.Count(); i++) {
                Debug.Log("selected: " + i);
                items[selected[i]].chance /= 2;
            }
            NormalizeChances();
        }

    }
}
