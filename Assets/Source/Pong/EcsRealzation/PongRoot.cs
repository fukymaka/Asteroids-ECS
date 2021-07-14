using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Source.Systems;
using UnityEngine;

namespace Source
{
    public class PongRoot : MonoBehaviour
    {
        [SerializeField] private Environment environment;
        [SerializeField] private GameSettings gameSettings;

        private EcsWorld _world;
        private EcsSystems _updateSystems;
        
        private void Awake()
        {
            _world = new EcsWorld();

            _updateSystems = new EcsSystems(_world)
                .Add(new AddForceToBallSystem())
                .Add(new SubscribePlatformCollisionSystem())
                .Add(new SubscribeLoseZoneOnTriggerEnterSystem())
                
                .Add(new MovePlatformSystem())
                .Add(new IncreaseScoreSystem())
                .Add(new UpdateScoreTextSystem())
                .Add(new ShowGameOverMenuSystem())
                
                .Inject(environment)
                .Inject(gameSettings);
            
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