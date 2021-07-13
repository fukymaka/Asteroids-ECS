using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Source.LeoECS.Components;
using Source.LeoECS.Systems;
using UnityEngine;

namespace Source.LeoECS {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            EcsWorldObserver.Create (_world);
            EcsSystemsObserver.Create (_systems);
#endif
            
            
            _systems
                .Add (new CreateEntitys())
                .Add (new PrintSystem())
                
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}