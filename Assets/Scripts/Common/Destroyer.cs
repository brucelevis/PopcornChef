using UnityEngine;

namespace PopcornChef {
    public class Destroyer : MonoBehaviour {

        [SerializeField]
        GameObject target;

        public void Destroy() {
            Destroy(target);
        }

    }
}
