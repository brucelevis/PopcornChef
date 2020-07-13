using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef.Game {
    [CreateAssetMenu]
    public class Order : ScriptableObject {

        
        public UnityEvent OnSubmit;

        public void Submit() {

        }

    }
}
