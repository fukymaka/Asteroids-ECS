using System;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AsteroidsECS
{
    public class AsteroidSpawnSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly AsteroidsSettings _asteroidsSettings = null;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<AsteroidSpawnRequest> _asteroidSpawnFilter = null;

        private GameObject _asteroidContainer;
        private float _boundHeight;
        private float _boundWidth;
        
        private const float ClearZoneRadius = 3f;

        public void Init()
        {
            CalculateBounds();
        }
        
        public void Run()
        {
            if (_asteroidSpawnFilter.IsEmpty())
                return;

            var asteroidSpawnRequest = _asteroidSpawnFilter.Get1(0);

            var generation = asteroidSpawnRequest.AsteroidGeneration;
            var spawnPosition = asteroidSpawnRequest.SpawnPosition;
            var asteroidPrefab = _asteroidsSettings.GetAsteroidPrefab(generation);

            if (spawnPosition == default)
                spawnPosition = GetAsteroidSpawnPos();

            var rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            var asteroid = Object.Instantiate(asteroidPrefab, spawnPosition, rotation);
            asteroid.AsteroidGeneration = generation;

            var asteroidSpeed = _asteroidsSettings.Speed * (int) generation;

            var asteroidMovementRequest = new AsteroidMovementRequest
            {
                Asteroid = asteroid,
                Speed = asteroidSpeed,
            };
            _world.NewEntityWith(asteroidMovementRequest);

            var boundsComponent = new BoundsComponent
            {
                Target = asteroid.transform
            };
            _world.NewEntityWith(boundsComponent);

            PutAsteroidInContainer(asteroid);
            
            _asteroidSpawnFilter.GetEntity(0).Destroy();
        }
        
        private void CalculateBounds()
        {
            var mainCamera = Camera.main;
            _boundHeight = mainCamera.orthographicSize;
            _boundWidth = _boundHeight * mainCamera.aspect;
        }
        
        private Vector2 GetAsteroidSpawnPos()
        {
            var startPos = Vector2.zero;

            //todo
            while (Math.Abs(startPos.x) < ClearZoneRadius && Math.Abs(startPos.y) < ClearZoneRadius)
            {
                startPos.x = Random.Range(-_boundWidth, _boundWidth);
                startPos.y = Random.Range(-_boundHeight, _boundHeight);
            }
            
            return startPos;
        }
        
        private void PutAsteroidInContainer(Asteroid asteroid)
        {
            if (_asteroidContainer == null) 
                _asteroidContainer = new GameObject("AsteroidContainer");

            asteroid.transform.SetParent(_asteroidContainer.transform);
        }
    }
}