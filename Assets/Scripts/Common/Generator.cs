using UnityEngine;

namespace PopcornChef {
    public class Generator : MonoBehaviour {

        public void Generate(GameObject target) {
            Instantiate(
                target,
                transform.position,
                transform.rotation,
                transform.parent
            );
        }

    }
}
