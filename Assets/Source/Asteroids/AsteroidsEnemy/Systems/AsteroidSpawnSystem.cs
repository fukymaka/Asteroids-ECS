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
        private float _clearZoneRadius = 3f;

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
            
            SpawnAsteroid(generation, spawnPosition);
            
            _asteroidSpawnFilter.GetEntity(0).Destroy();
        }

        private void SpawnAsteroid(int generation, Vector2 spawnPosition)
        {
            var asteroid = _asteroidsSettings.GetAsteroidPrefab(generation);

            if (spawnPosition == default)
                spawnPosition = GetAsteroidSpawnPos();

            var rotation = Quaternion.Euler(0, 0, Random.Range(0, 359));
            asteroid = Object.Instantiate(asteroid, spawnPosition, rotation);

            var asteroidSpeed = _asteroidsSettings.Speed * generation;

            var asteroidComponent = new AsteroidComponent
            {
                Asteroid = asteroid,
                Generation = generation,
                Speed = asteroidSpeed,
                IsInit = false
            };
            var asteroidEntity = _world.NewEntityWith(asteroidComponent);

            var boundsComponent = new BoundsComponent
            {
                Sender = asteroid.transform
            };
            asteroidEntity.Replace(boundsComponent);
            asteroidEntity.Replace(asteroidComponent);

            PutAsteroidInContainer(asteroid);
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
            while (Math.Abs(startPos.x) < _clearZoneRadius && Math.Abs(startPos.y) < _clearZoneRadius)
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