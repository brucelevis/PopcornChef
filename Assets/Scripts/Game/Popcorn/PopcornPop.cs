using UnityEngine;

namespace PopcornChef.Game {
    public class PopcornPop : MonoBehaviour {

        public GameObject PoppedPrefab;

        public void Pop() {
            Instantiate(PoppedPrefab, transform.position, transform.rotation, transform.parent);
            Destroy(gameObject);
        }

    }
}
