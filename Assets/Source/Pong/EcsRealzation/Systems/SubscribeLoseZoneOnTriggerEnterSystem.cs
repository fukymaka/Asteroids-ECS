using Leopotam.Ecs;

namespace Source.Systems
{
    public class SubscribeLoseZoneOnTriggerEnterSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly Environment _environment = null;
        
        public void Init()
        {
            _environment.LoseZone1.OnTriggerEnter += OnTriggerEnterHandler;
            _environment.LoseZone2.OnTriggerEnter += OnTriggerEnterHandler;
        }

        private void OnTriggerEnterHandler()
        {
            var entity = _world.NewEntity();
            entity.Get<GameOverTag>();
        }
    }
}