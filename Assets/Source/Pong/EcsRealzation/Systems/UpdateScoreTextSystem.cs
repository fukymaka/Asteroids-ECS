using Leopotam.Ecs;

namespace Source.Systems
{
    public class UpdateScoreTextSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly PongEnvironment _pongEnvironment = null;

        private readonly EcsFilter<ScoreComponent> _scoreFilter = null;

        public void Init()
        {
            var entity = _world.NewEntity();
            entity.Get<ScoreComponent>();
        }

        public void Run()
        {
            var canvasEnvironment = _pongEnvironment.CanvasEnvironment;

            var scoreComponent = _scoreFilter.Get1(0);

            var score = scoreComponent.Score;
            canvasEnvironment.ScoreText.text = score.ToString();
        }
    }
}