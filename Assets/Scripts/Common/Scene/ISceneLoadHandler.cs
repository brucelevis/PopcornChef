using Cysharp.Threading.Tasks;

namespace PopcornChef {
    public interface ISceneLoadHandler {
        UniTask OnLoadSceneStarted();
        UniTask OnLoadSceneFinished();
    }
}