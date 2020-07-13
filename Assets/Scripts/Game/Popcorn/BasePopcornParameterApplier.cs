using UnityEngine;
using UniRx;

namespace PopcornChef.Game {
    public abstract class BasePopcornParameterApplier : MonoBehaviour {
        public FloatReactiveProperty seed;
    }
}
