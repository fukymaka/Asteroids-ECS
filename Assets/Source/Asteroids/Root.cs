using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

namespace AsteroidsECS
{
    public class Root : MonoBehaviour
    {
        [SerializeField] private Environment environment;
        [SerializeField] private PlayerSettings playerSettings;
        [SerializeField] private AsteroidsSettings asteroidsSettings;

        private EcsWorld _world;
        private EcsSystems _updateSystems;

        private void Awake()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world)
                .Add(new GameInitSystem())
                .Add(new PlayerMovementSystem())
                .Add(new PlayerShootingSystem())
                .Add(new AsteroidSpawnSystem())
                .Add(new AsteroidMovementSystem())
                .Add(new BoundsControlSystem())
                .Add(new ShootingSystem())
                .Inject(environment)
                .Inject(playerSettings)
                .Inject(asteroidsSettings);

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