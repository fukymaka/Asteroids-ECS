using Leopotam.Ecs;

namespace Source.Systems
{
    public class SubscribePlatformCollisionSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly Environment _environment = null;
        
        public void Init()
        {
            _environment.Platform1.OnCollision += OnCollisionHandler;
            _environment.Platform2.OnCollision += OnCollisionHandler;
        }

        private void OnCollisionHandler()
        {
            var entity = _world.NewEntity();
            entity.Get<IncreaseScoreRequest>();
        }
    }
}