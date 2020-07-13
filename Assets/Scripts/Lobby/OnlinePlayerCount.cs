using UnityEngine;
using TMPro;

namespace PopcornChef.Lobby {
    public class OnlinePlayerCount : MonoBehaviour {

        [SerializeField]
        ServerConnector serverConnector;

        [SerializeField]
        TextMeshProUGUI text;

        const string format = "{0} 人がプレイ中!!";

        public void Reflesh() {
            text.text = string.Format(format, serverConnector.GetOnlinePlayerCount());
        }

    }
}