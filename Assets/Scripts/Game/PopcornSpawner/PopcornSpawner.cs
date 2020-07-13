using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace PopcornChef.Game {
    public class PopcornSpawner : MonoBehaviour {

        struct Generation {
            public readonly BasePopcornParameterApplier prefab;
            public readonly float seed;
            public readonly IPositionGetter positionGetter;

            public Generation(
                BasePopcornParameterApplier prefab,
                float seed,
                IPositionGetter positionGetter
            ) {
                this.prefab = prefab;
                this.seed = seed;
                this.positionGetter = positionGetter;
            }
        }

        interface IPositionGetter {
            bool TryGetPosition(out Vector2 position);
        }

        class ExplicitPositionGetter : IPositionGetter {
            public readonly Vector2 position;

            public ExplicitPositionGetter(Vector2 position) {
                this.position = position;
            }

            public bool TryGetPosition(out Vector2 position) {
                position = this.position;
                return true;
            }
        }

        class FinderPositionGetter : IPositionGetter {
            public readonly SafePositionFinder positionFinder;

            public FinderPositionGetter(SafePositionFinder finder) {
                this.positionFinder = finder;
            }

            public bool TryGetPosition(out Vector2 position) {
                if (positionFinder.TryGetPosition(out var pos)) {
                    position = pos;
                    return true;
                } else {
                    position = Vector2.zero;
                    return false;
                }
            }
        }

        public int QueueSize = 20;
        public bool StopGeneration = false;
        public Transform SpawnParent;
        List<Generation> waitingGenerations = new List<Generation>();

        public bool TryGenerate(
            BasePopcornParameterApplier prefab,
            float seed,
            Vector2 position
        ) {
            return TryAddToQueue(
                new Generation(prefab, seed, new ExplicitPositionGetter(position))
            );
        }

        public bool TryGenerate(
            BasePopcornParameterApplier prefab,
            float seed,
            SafePositionFinder positionFinder
        ) {
            return TryAddToQueue(
                new Generation(prefab, seed, new FinderPositionGetter(positionFinder))
            );
        }

        bool TryAddToQueue(Generation generation) {
            if (waitingGenerations.Count >= QueueSize) return false;
            waitingGenerations.Add(generation);
            return true;
        }

        public void Update() {
            SpawnFromQueue();
        }

        void SpawnFromQueue() {
            if (StopGeneration) return;
            List<int> generatedIndice = new List<int>();
            for (int i = 0; i < waitingGenerations.Count; i++) {
                var generation = waitingGenerations[i];
                if (!generation.positionGetter.TryGetPosition(out Vector2 position)) continue;
                Spawn(generation.prefab, generation.seed, position);
                generatedIndice.Add(i);
            }
            for (int i = generatedIndice.Count - 1; i >= 0; i--) {
                waitingGenerations.RemoveAt(generatedIndice[i]);
            }
        }

        void Spawn(BasePopcornParameterApplier prefab, float seed, Vector2 position) {
            var instance = Instantiate(prefab, position, Quaternion.identity, SpawnParent);
            instance.seed.SetValueAndForceNotify(seed);
        }

    }
}
