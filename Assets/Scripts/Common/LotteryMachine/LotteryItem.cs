using System;

namespace PopcornChef.Game {
    public class LotteryItem<T> {
        public T item;
        public float chance;

        public LotteryItem(T item, float chance) {
            this.item = item;
            this.chance = chance;
        }

        public LotteryItem(LotteryItem<T> cp) {
            item = cp.item;
            chance = cp.chance;
        }
    }
}
