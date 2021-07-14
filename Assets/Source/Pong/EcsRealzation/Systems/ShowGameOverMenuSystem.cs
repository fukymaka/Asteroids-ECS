using Leopotam.Ecs;

namespace Source.Systems
{
    public class ShowGameOverMenuSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverTag> _gameOverFilter = null;
        
        private readonly Environment _environment = null;
        
        public void Run()
        {
            if (_gameOverFilter.IsEmpty())
                return;

            var canvasGroup = _environment.CanvasEnvironment.CanvasGroup;
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }
    }
}