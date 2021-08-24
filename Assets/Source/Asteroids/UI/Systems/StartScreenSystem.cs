using AsteroidsECS.Services.Components;
using Leopotam.Ecs;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS.UI.Systems
{
    public class StartScreenSystem : IEcsInitSystem
    {
        private readonly UiEnvironment _uiEnvironment = null;
        private readonly EcsWorld _world = null;
        
        public void Init()
        {
            var playButton = _uiEnvironment.StartScreenUi.PlayButton;
            playButton.onClick.AddListener(() => StartGame());
        }

        private void StartGame()
        {
            _world.NewEntityWith<StartGameRequest>();
            _uiEnvironment.StartScreenUi.gameObject.SetActive(false);
        }
    }
}