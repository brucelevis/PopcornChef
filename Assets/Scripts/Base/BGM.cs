using UnityEngine;

namespace PopcornChef.Base {
    [CreateAssetMenu(menuName = "PopcornChef/Audio/BGM")]
    public class BGM : ScriptableObject {

        public AudioClipGameEvent OnUpdate;
        public GameEvent OnStop;

        public void UpdateBGM(AudioClip bgm) {
            OnUpdate.Raise(bgm);
        }

        public void StopBGM() {
            OnStop.Raise();
        }

    }
}
