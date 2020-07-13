using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace PopcornChef.Game {
    public class SafePositionFinder : MonoBehaviour {

        public int xGridCount = 4;
        public int yGridCount = 3;
        public Vector2 gridSize = new Vector2(2f, 2f);
        public Vector2 bottomLeftPosition = new Vector2(-3f, 8f);
        public int popcornLayerMask;

        List<int> usedGenerationOrder = new List<int>();
        List<int> generationOrder = new List<int>();
        BoxCollider2D[] generationGridsCollider = null;

        void Awake() {
            GenerateGrids();
        }

        void LateUpdate() {
            RefleshGenerationOrder();
        }

        void GenerateGrids() {
            generationOrder = Enumerable.Range(0, xGridCount * yGridCount).OrderBy(i => Guid.NewGuid()).ToList();
            generationGridsCollider = new BoxCollider2D[xGridCount * yGridCount];
            for (int i = 0; i < xGridCount * yGridCount; i++) {
                var x = i / yGridCount;
                var y = i % yGridCount;
                var gridGameObject = new GameObject($"Grid(x: {x}, y: {y})");
                gridGameObject.transform.SetParent(gameObject.transform);
                var collider = gridGameObject.AddComponent<BoxCollider2D>();
                collider.isTrigger = true;
                collider.offset = bottomLeftPosition + Vector2.Scale(gridSize, new Vector2(x, y));
                collider.size = gridSize;
                generationGridsCollider[i] = collider;
            }
        }

        void RefleshGenerationOrder() {
            generationOrder.AddRange(usedGenerationOrder);
            usedGenerationOrder.Clear();
        }

        public bool TryGetPosition(out Vector2 position) {
            for (int i = 0; i < generationOrder.Count; i++) {
                int num = generationOrder[i];
                if (generationGridsCollider[num].IsTouchingLayers(popcornLayerMask)) {
                    continue;
                }
                generationOrder.RemoveAt(i);
                usedGenerationOrder.Add(num);
                position = generationGridsCollider[num].offset;
                return true;
            }

            position = Vector2.zero;
            return false;
        }

    }
}
