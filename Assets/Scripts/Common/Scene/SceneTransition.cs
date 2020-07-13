using System;

namespace PopcornChef {
    [Serializable]
    public struct SceneTransition {
        public SceneBase UnloadScene;
        public SceneBase LoadScene;
    }
}
