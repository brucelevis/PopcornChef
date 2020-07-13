using Cysharp.Threading.Tasks;
using UnityEngine;

namespace PopcornChef.Start {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/StartScene")]
    public class StartScene : SceneBase {

        [SerializeField] ServerConnector serverConnector;

        public override async UniTask AfterUnloadScene() {}

        public override async UniTask BeforeLoadScene() {
            await serverConnector.DisconnectFromServer();
        }

    }
}