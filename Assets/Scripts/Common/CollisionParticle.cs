using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace PopcornChef.Game {
    public class CollisionParticle : MonoBehaviour {

        static Mesh baseMesh;

        [SerializeField]
        Transform _transform;

        [SerializeField]
        Collider2D _collider;

        [SerializeField]
        ParticleSystem _particleSystem;

        /// <summary>
        ///   すべての衝突メッシュを格納した配列
        /// </summary>
        List<CombineInstance> combineInstances = new List<CombineInstance>();

        void Awake() {
            var s = _particleSystem.shape;
            s.mesh = new Mesh();
        }

        void Start() {
            _collider.OnCollisionStay2DAsObservable().Subscribe(UpdateMesh).AddTo(this);
        }

        void Update() {
            if (_particleSystem == null) return;
            // メッシュをリセットする
            _particleSystem.shape.mesh.Clear();

            if (combineInstances.Count > 0) {
                // 他コライダーとの衝突点が存在する場合
                _particleSystem.shape.mesh.CombineMeshes(combineInstances.ToArray());
                if (!_particleSystem.isPlaying) _particleSystem.Play();
            } else {
                // 他コライダーとの衝突点が存在しない場合
                _particleSystem.Stop();
            }
        }

        void FixedUpdate() {
            combineInstances.Clear();
        }

        void OnDestroy() {
            if (_particleSystem == null) return;
            var s = _particleSystem.shape;
            GameObject.Destroy(s.mesh);
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void GenerateBaseMesh() {
            baseMesh = new Mesh();
            baseMesh.vertices = new Vector3[] {
                new Vector3(0f, 0f),
                new Vector3(0.1f, 0f),
                new Vector3(0.1f, 0.2f),
                new Vector3(0f, 0.2f),
            };
            baseMesh.triangles = new int[] { 0, 1, 2, 2, 3, 0 };
            baseMesh.RecalculateNormals();
            baseMesh.RecalculateBounds();
        }

        void UpdateMesh(Collision2D other) {
            var points = new List<ContactPoint2D>();
            int contactCount = other.GetContacts(points);
            combineInstances.AddRange(
                points.Take(contactCount).Select(point => new CombineInstance() {
                    mesh = baseMesh,
                    transform = Matrix4x4.Translate(Vector3.Scale(_transform.localScale, _transform.InverseTransformPoint(point.point)))
                })
            );
            points.Clear();
        }

    }
}
