using Leopotam.Ecs;

namespace Source.Systems
{
    public class SubscribeLoseZoneOnTriggerEnterSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly PongEnvironment _pongEnvironment = null;
        
        public void Init()
        {
            _pongEnvironment.LoseZone1.OnTriggerEnter += OnTriggerEnterHandler;
            _pongEnvironment.LoseZone2.OnTriggerEnter += OnTriggerEnterHandler;
        }

        private void OnTriggerEnterHandler()
        {
            var entity = _world.NewEntity();
            entity.Get<GameOverTag>();
        }
    }
}