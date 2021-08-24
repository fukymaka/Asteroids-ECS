using AsteroidsECS.Services.Components;
using AsteroidsECS.Services.Enums;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class GameInitSystem : IEcsRunSystem
    {
        private readonly PlayerSettings _playerSettings = null;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<StartGameRequest> _startGameFilter = null;

        public void Run()
        {
            if (_startGameFilter.IsEmpty())
                return;
            
            InitPlayer();
            InitAsteroids();
            InitUfos();
            
            _startGameFilter.GetEntity(0).Destroy();
        }
        
        private void InitPlayer()
        {
            var player = Object.Instantiate(_playerSettings.PlayerPrefab);

            var playerMoveComponent = new PlayerComponent
            {
                Player = player
            };
            _world.NewEntityWith(playerMoveComponent);

            var boundsComponent = new BoundsComponent
            {
                Target = player.transform
            };
            _world.NewEntityWith(boundsComponent);
        }
        
        private void InitAsteroids()
        {
            var asteroidsSpawnRequest = new AsteroidSpawnRequest
            {
                AsteroidGeneration = AsteroidGeneration.First
            };
            _world.NewEntityWith(asteroidsSpawnRequest);
            _world.NewEntityWith(asteroidsSpawnRequest);
            _world.NewEntityWith(asteroidsSpawnRequest);
        }

        private void InitUfos()
        {
            _world.NewEntityWith<UfoInitSpawnComponent>();
        }
    }
}