using UnityEngine;

namespace PopcornChef.Lobby {
    public class JoiningDialog : MonoBehaviour {

        [SerializeField]
        AnimatorSwitch switchableAnimator;

        bool isMatchingRandom = false;
        bool isMatchingPrivate = false;

        public void SetMatchingRandomState(bool isMatchingRandom) {
            this.isMatchingRandom = isMatchingRandom;
            UpdateSwitch();
        }

        public void SetMatchingPrivateState(bool isMatchingPrivate) {
            this.isMatchingPrivate = isMatchingPrivate;
            UpdateSwitch();
        }

        public void UpdateSwitch() {
            switchableAnimator.SetSwitchAndForget(
                isMatchingRandom | isMatchingPrivate
            );
        }

    }
}