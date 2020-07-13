using UnityEngine;

namespace PopcornChef.Base {
    public class LoadingSceneDialog : MonoBehaviour {

        [SerializeField]
        AnimatorSwitch switchableAnimator;

        bool isLoading = false;
        bool isUnloading = false;

        public void SetLoadingState(bool isLoading) {
            this.isLoading = isLoading;
            UpdateSwitch();
        }

        public void SetUnloadingState(bool isUnloading) {
            this.isUnloading = isUnloading;
            UpdateSwitch();
        }

        public void UpdateSwitch() {
            switchableAnimator.SetSwitchAndForget(
                isLoading | isUnloading
            );
        }

    }
}
