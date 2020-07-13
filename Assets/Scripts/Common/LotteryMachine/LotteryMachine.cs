using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Lottery/LotteryMachine")]
    public class LotteryMachine<TArg, TItem> : ScriptableObject, ISerializationCallbackReceiver where TItem : LotteryItem<TArg> {

        public List<TItem> InitialItems;

        public List<TItem> items;

        public TArg Draw() {
            return DrawRange(1).First();
        }

        public IEnumerable<TArg> DrawRange(int count) {
            count = Mathf.Min(count, items.Count);
            float sum = items.Select(x => x.chance).Sum();
            List<int> indice = Enumerable.Range(0, items.Count).ToList();
            // 最終的に選択されたアイテムのインデックス
            int[] selected = new int[count];

            for (int i = 0; i < count; i++) {
                float[] cpd = indice.Select(x => items[x].chance).ToArray();
                int index = CPD.BinarySearchInCPD(cpd, UnityEngine.Random.Range(0f, sum));
                int choice = indice[index];
                indice.RemoveAt(index);
                selected[i] = choice;
                sum -= items[choice].chance;
            }

            UpdateItems(selected);
            return selected.Select(x => items[x].item);
        }

        public virtual void UpdateItems(int[] selected) { }

        public void NormalizeChances() {
            float sum = items.Select(x => x.chance).Sum();
            for (int i = 0; i < items.Count; i++) {
                if (items[i].chance <= 0f) {
                    items[i].chance = 0f;
                    continue;
                }
                items[i].chance = Mathf.Max(float.MinValue, items[i].chance / sum);
            }
        }

        public void OnAfterDeserialize() {
            items = new List<TItem>();
            for (int i = 0; i < InitialItems.Count; i++) {
                items.Add(Activator.CreateInstance(typeof(TItem), InitialItems[i]) as TItem);
            }
        }

        public void OnBeforeSerialize() { }

    }
}
