using System;

namespace PopcornChef.Game {
    [Serializable]
    public class PopcornLotteryItem : LotteryItem<BasePopcornParameterApplier> {
        public PopcornLotteryItem(BasePopcornParameterApplier item, float chance) : base(item, chance) {}
        public PopcornLotteryItem(PopcornLotteryItem cp) : base(cp) {}
    }
}
