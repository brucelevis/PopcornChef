using UnityEngine;
using System.Collections.Generic;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Scene/SceneRegister")]
    public class SceneRegister : ScriptableObject {
        public List<SceneBase> Scenes;
    }
}