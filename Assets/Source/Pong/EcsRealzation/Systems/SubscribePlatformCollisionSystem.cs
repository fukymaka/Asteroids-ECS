using Leopotam.Ecs;

namespace Source.Systems
{
    public class SubscribePlatformCollisionSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly PongEnvironment _pongEnvironment = null;
        
        public void Init()
        {
            _pongEnvironment.Platform1.OnCollision += OnCollisionHandler;
            _pongEnvironment.Platform2.OnCollision += OnCollisionHandler;
        }

        private void OnCollisionHandler()
        {
            var entity = _world.NewEntity();
            entity.Get<IncreaseScoreRequest>();
        }
    }
}