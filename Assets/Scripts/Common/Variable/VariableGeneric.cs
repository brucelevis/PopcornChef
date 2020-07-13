using UnityEngine;
using System;

namespace PopcornChef {
    public class Variable<T> : ScriptableObject, ISerializationCallbackReceiver {

        public T InitialValue;

        [NonSerialized]
        public T RuntimeValue;

        public void OnAfterDeserialize() {
            RuntimeValue = InitialValue;
        }

        public void OnBeforeSerialize() { }

    }
}