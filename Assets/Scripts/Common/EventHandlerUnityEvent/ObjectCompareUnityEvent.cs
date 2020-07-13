using UnityEngine;
using UnityEngine.Events;

namespace PopcornChef {
    public class ObjectCompareUnityEvent : MonoBehaviour {

        public Object baseObject;
        public UnityEvent OnSame;
        public UnityEvent OnNotSame;

        public void Compare(Object obj) {
            if (obj == baseObject) {
                OnSame.Invoke();
            } else {
                OnNotSame.Invoke();
            }
        }

    }
}
