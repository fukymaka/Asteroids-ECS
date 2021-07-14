using Leopotam.Ecs;

namespace Source.Systems
{
    public class IncreaseScoreSystem : IEcsRunSystem
    {
        private readonly EcsFilter<IncreaseScoreRequest> _increaseScoreFilter = null;
        private readonly EcsFilter<ScoreComponent> _scoreFilter = null;
        private readonly EcsFilter<GameOverTag> _gameOverFilter = null;

        public void Run()
        {
            if (!_gameOverFilter.IsEmpty())
                return;
            
            if (_increaseScoreFilter.IsEmpty())
                return;
            
            _increaseScoreFilter.GetEntity(0).Destroy();
            ref var scoreComponent = ref _scoreFilter.Get1(0);
            scoreComponent.Score++;
        }
    }
}