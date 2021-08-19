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
        [SerializeField] private UfoSettings ufoSettings;

        private EcsWorld _world;
        private EcsSystems _updateSystems;

        private void Awake()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world)
                
                .Add(new PlayerMovementSystem())
                .Add(new PlayerShootingSystem())
                .Add(new AsteroidSpawnSystem())
                .Add(new AsteroidMovementSystem())
                .Add(new UfoSpawnSystem())
                .Add(new UfoMovementSystem())
                .Add(new BoundsControlSystem())
                .Add(new ShootingSystem())
                .Add(new GameInitSystem())
                .Add(new DestroyerSystem())
                .Inject(environment)
                .Inject(playerSettings)
                .Inject(asteroidsSettings)
                .Inject(ufoSettings);

            _updateSystems.Init();

            InitCollisionBridge();

#if UNITY_EDITOR
            EcsWorldObserver.Create(_world);
            EcsSystemsObserver.Create(_updateSystems);
#endif
        }

        private void InitCollisionBridge()
        {
            var collsionBridge = new GameObject("[CollisionBridge]");
            var collsionBridgeComponent = collsionBridge.AddComponent<CollisionUnityBridge>();
            collsionBridgeComponent.SetWorld(_world);
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