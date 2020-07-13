using UnityEngine;
using System.Collections.Generic;

namespace PopcornChef {
    [CreateAssetMenu(menuName = "PopcornChef/State/GameStateMachine")]
    public class GameStateMachine : ScriptableObject {

        public int EnterStateIndex;

        [SerializeField]
        List<GameState> States;

        int previousStateIndex = -1;
        int currentStateIndex = 0;

        public void InitializeStateMachine() {
            for (int i = 0; i < States.Count; i++) {
                States[i].OnEnter.RaiseOnRegister = false;
                States[i].OnExit.RaiseOnRegister = false;
            }
            UpdateState(EnterStateIndex);
        }

        public void FinalizeStateMachine() {
            for (int i = 0; i < States.Count; i++) {
                States[i].OnEnter.RaiseOnRegister = false;
                States[i].OnExit.RaiseOnRegister = false;
            }
        }

        public void UpdateState(int nextIndex) {
            previousStateIndex = currentStateIndex;
            currentStateIndex = nextIndex;

            var previous = States[previousStateIndex];
            if (previous != null && previous.OnExit != null) {
                previous.OnExit.Raise();
                previous.OnEnter.RaiseOnRegister = false;
                previous.OnExit.RaiseOnRegister = true;
            }

            var current = States[currentStateIndex];
            if (current != null && current.OnEnter != null) {
                current.OnEnter.RaiseOnRegister = true;
                current.OnExit.RaiseOnRegister = false;
                current.OnEnter.Raise();
            }
        }

        public void UpdateState(GameState next) {
            int index = States.IndexOf(next);
            if (index == -1) {
                Debug.LogWarning($"状態({next.name})に移行しようとしましたが、この状態はステートマシン({name})に含まれていません。スキップします。");
                return;
            }
            UpdateState(index);
        }

    }
}
