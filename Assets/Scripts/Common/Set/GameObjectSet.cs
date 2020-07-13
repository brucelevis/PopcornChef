using UnityEngine;
using System.Collections.Generic;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Set/GameObjectSet")]
    public class GameObjectSet : ScriptableObject {

        List<GameObject> elements;
        public List<GameObject> Elements => elements;

        public void Add(GameObject gameObject) {
            elements.Add(gameObject);
        }

        public void Remove(GameObject gameObject) {
            elements.Remove(gameObject);
        }

    }
}