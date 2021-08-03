using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace Source.StateMachine
{
    public class ThemeRoot : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _updateSystems;

        private void Awake()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world)
                .Add(new OnThemeScreenSystem());
            // .Inject();

            _updateSystems.Init();

#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
            EcsSystemsObserver.Create(_updateSystems);
#endif
        }

        private void Update()
        {
            _updateSystems.Run();
        }

        private void OnDestroy()
        {
            _updateSystems.Destroy();
            _world.Destroy();
        }
    }
}