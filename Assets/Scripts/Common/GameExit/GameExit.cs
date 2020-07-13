using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/GameExit")]
    public class GameExit : ScriptableObject {

        public GameEvent OnExit;

        void Awake() {
            OnExit = ScriptableObject.CreateInstance<GameEvent>();
        }

        public void ExitGame() {
            OnExit.Raise();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
            UnityEngine.Application.Quit();
#endif
        }

    }
}
