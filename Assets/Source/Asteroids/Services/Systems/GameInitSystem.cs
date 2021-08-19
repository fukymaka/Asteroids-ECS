﻿using AsteroidsECS.Services.Enums;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class GameInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly PlayerSettings _playerSettings = null;
        // private readonly EcsFilter<PlayerInitRequest> _playerInitFilter = null;
        
        // public void Run()
        // {
        //     if (_playerInitFilter.IsEmpty())
        //         return;    
        // }

        public void Init()
        {
            InitPlayer();
            InitAsteroids();
            InitUfos();
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