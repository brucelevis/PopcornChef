using UnityEngine;

namespace PopcornChef {
    public abstract class SceneInitializer : MonoBehaviour {
        public abstract void InitializeScene();
        public abstract void FinalizeScene();
    }
}
