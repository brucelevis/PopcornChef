using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/Event/GameEvent")]
    public class GameEvent : ScriptableObject {

        List<GameEventListener> listeners = new List<GameEventListener>();
        public bool DebugOutput = false;
        public bool RaiseOnRegister = false;
        public UnityEvent OnRaise;

        public void Raise() {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Raised");
            }
            for(int i = listeners.Count -1; i >= 0; i--) {
                listeners[i].OnEventRaised();
            }
            OnRaise.Invoke();
        }

        public void RegisterListener(GameEventListener listener) {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Register: {listener.name}" + (RaiseOnRegister ? " (and Raised)" : ""));
            }
            listeners.Add(listener);
            if (RaiseOnRegister) {
                listener.OnEventRaised();
            }
        }

        public void UnregisterListener(GameEventListener listener) {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Unregister: {listener.name}");
            }
            listeners.Remove(listener);
        }

    }
}
