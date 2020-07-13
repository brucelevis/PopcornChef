using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

namespace PopcornChef {
    public class GameEvent<TArg, TUnityEvent> : ScriptableObject
        where TUnityEvent : UnityEvent<TArg> {

        List<GameEventListener<TArg, TUnityEvent>> listeners = new List<GameEventListener<TArg, TUnityEvent>>();
        public bool DebugOutput = false;
        public bool RaiseOnRegister = false;
        public TArg RaiseOnRegisterArg;
        public TUnityEvent OnRaise;

        public void Raise(TArg arg) {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Raised with argument {arg.ToString()}");
            }
            for(int i = listeners.Count -1; i >= 0; i--) {
                listeners[i].OnEventRaised(arg);
            }
            OnRaise.Invoke(arg);
        }

        public void RegisterListener(GameEventListener<TArg, TUnityEvent> listener) {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Register: {listener.name}" + (RaiseOnRegister ? $" (and Raised with argument {RaiseOnRegisterArg.ToString()})" : ""));
            }
            listeners.Add(listener);
            if (RaiseOnRegister) {
                listener.OnEventRaised(RaiseOnRegisterArg);
            }
        }

        public void UnregisterListener(GameEventListener<TArg, TUnityEvent> listener) {
            if (DebugOutput) {
                Debug.Log($"[GameEvent({name})] Unregister: {listener.name}");
            }
            listeners.Remove(listener);
        }

    }

    public class GameEventListener<TArg, TUnityEvent> : MonoBehaviour
        where TUnityEvent : UnityEvent<TArg> {

        public TUnityEvent Response;

        public void OnEventRaised(TArg arg) {
            Response.Invoke(arg);
        }

    }
}
