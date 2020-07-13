using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PopcornChef.Lobby {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/LobbyScene")]
    public class LobbyScene : SceneBase {

        [SerializeField] ServerConnector serverConnector;

        public override async UniTask AfterUnloadScene() {}

        public override async UniTask BeforeLoadScene() {
            await serverConnector.ConnectToServer();
            await serverConnector.LeaveRoom();
        }

    }
}