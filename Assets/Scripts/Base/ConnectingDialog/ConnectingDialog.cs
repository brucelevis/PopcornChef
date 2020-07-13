using UnityEngine;

namespace PopcornChef.Base {
    public class ConnectingDialog : MonoBehaviour {

        [SerializeField]
        AnimatorSwitch switchableAnimator;

        bool isConnecting = false;
        bool isDisconnecting = false;
        bool isJoiningRoom = false;
        bool isLeavingRoom = false;

        public void SetConnectingState(bool isConnecting) {
            this.isConnecting = isConnecting;
            UpdateSwitch();
        }

        public void SetDisconnectingState(bool isDisconnecting) {
            this.isDisconnecting = isDisconnecting;
            UpdateSwitch();
        }

        public void SetJoiningRoomState(bool isJoiningRoom) {
            this.isJoiningRoom = isJoiningRoom;
            UpdateSwitch();
        }

        public void SetLeavingRoomState(bool isLeavingRoom) {
            this.isLeavingRoom = isLeavingRoom;
            UpdateSwitch();
        }

        public void UpdateSwitch() {
            switchableAnimator.SetSwitchAndForget(
                isConnecting | isDisconnecting | isJoiningRoom | isLeavingRoom
            );
        }

    }
}
