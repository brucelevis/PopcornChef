using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PopcornChef.Game {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/GameScene")]
    public class GameScene : SceneBase {

        [SerializeField] ServerConnector serverConnector;

        public override async UniTask AfterUnloadScene() {}

        public override async UniTask BeforeLoadScene() {
            await serverConnector.ConnectToServer();
            await serverConnector.MatchRandomRoom();
        }

    }
}