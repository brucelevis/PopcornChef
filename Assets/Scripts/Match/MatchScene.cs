using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PopcornChef.Match {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/MatchScene")]
    public class MatchScene : SceneBase {

        [SerializeField] ServerConnector serverConnector;

        public override async UniTask AfterUnloadScene() {}

        public override async UniTask BeforeLoadScene() {
            await serverConnector.ConnectToServer();
            await serverConnector.MatchRandomRoom();
        }

    }
}