using UnityEngine;

namespace PopcornChef.Game {
    public class PopcornScoreApplier : MonoBehaviour {

        public float score;

        [SerializeField]
        FloatVariable playerScore;

        public void ApllyScore() {
            playerScore.Value = playerScore.Value + score;
        }

    }
}
