using System;
using System.Collections;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace AsteroidsECS
{
    public class UfoSpawnSystem : IEcsRunSystem
    {
        private readonly UfoSettings _ufoSettings = null;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<UfoInitSpawnComponent> _ufoInitSpawnFilter = null;

        private float _timer;
        private GameObject _ufoContainer;
        private readonly float _offsetBounds = 3f;

        public void Run()
        {
            if (_ufoInitSpawnFilter.IsEmpty())
                return;

            _timer += Time.deltaTime;

            if (_timer < _ufoSettings.UfoIntervalSpawn)
                return;

            var typeForSpawn = Random.Range(1, 3);
            SpawnUfo((UfoType) typeForSpawn);
            _timer = 0;
        }


        private void SpawnUfo(UfoType ufoType)
        {
            var ufo = _ufoSettings.GetUfoPrefab(ufoType);
            var startPosition = GetUfoSpawnPos();
            ufo = Object.Instantiate(ufo, startPosition, Quaternion.identity);
            ufo.UfoType = ufoType;

            var ufoMovementComponent = new UfoMovementComponent
            {
                ufo = ufo
            };
            _world.NewEntityWith(ufoMovementComponent);
            
            // ufo.SetProjectilePrefab(prefabsHolder.UfoProjectile);
            // ufo.SetProjectileSpeed(ufoSettings.ProjectileSpeed);

            var speedMultiplier = (int) ufoType;
            // var ufoMaxSpeed = ufoSettings.MaxSpeed * speedMultiplier;
            // var ufoMinSpeed = ufoSettings.MinSpeed * speedMultiplier;
            // ufo.Move(ufoMaxSpeed, ufoMinSpeed);

            PutUfoInContainer(ufo);
        }
        
        private Vector2 GetUfoSpawnPos()
        {
            var mainCamera = Camera.main;
            var boundHeight = mainCamera.orthographicSize;
            var boundWidth = boundHeight * mainCamera.aspect;
            var boundWidthWithOffset = boundWidth + _offsetBounds;
            var boundHeightWithOffset = boundHeight + _offsetBounds;

            var startPos = Vector2.zero;

            //todo
            while (Math.Abs(startPos.x) < boundWidth && Math.Abs(startPos.y) < boundHeight)
            {
                startPos.x = Random.Range(-boundWidthWithOffset, boundWidthWithOffset);
                startPos.y = Random.Range(-boundHeightWithOffset, boundHeightWithOffset);
            }
            
            return startPos;
        }
        
        private void PutUfoInContainer(Ufo ufo)
        {
            if (_ufoContainer == null) 
                _ufoContainer = new GameObject("UfoContainer");

            ufo.transform.SetParent(_ufoContainer.transform);
        }
    }
}