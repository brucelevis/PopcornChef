using UnityEngine;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Event/SceneTransitionGameEvent")]
    public class SceneTransitionGameEvent : GameEvent<SceneTransition, SceneTransitionUnityEvent> {}
}
