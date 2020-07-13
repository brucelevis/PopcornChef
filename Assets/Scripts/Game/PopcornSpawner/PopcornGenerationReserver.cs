using UnityEngine;

namespace PopcornChef.Game {
    public class PopcornGenerationReserver : MonoBehaviour {

        [SerializeField]
        PopcornLotteryMachine popcornTypeLotteryMachine;

        [SerializeField]
        FloatRandomValueGenerator seedGenerator;

        [SerializeField]
        PopcornSpawner spawner;

        [SerializeField]
        SafePositionFinder positionFinder;

        public void ReserveGeneration() {
            float seed = seedGenerator.GetRandomValue();
            spawner.TryGenerate(popcornTypeLotteryMachine.Draw(), seed, positionFinder);
        }

    }
}
