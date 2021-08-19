using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class UfoMovementSystem : IEcsRunSystem
    {
        private readonly UfoSettings _ufoSettings = null;
        private readonly EcsFilter<UfoMovementComponent> _ufoMovementFilter = null;
        
        public void Run()
        {
            if(_ufoMovementFilter.IsEmpty())
                return;

            foreach (var index in _ufoMovementFilter)
            {
                ref var ufoMovementComponent = ref _ufoMovementFilter.Get1(index);
                if (ufoMovementComponent.ufo == null)
                {
                    _ufoMovementFilter.GetEntity(index).Destroy();
                    continue;
                }
                
                Move(ref ufoMovementComponent);
            }
        }

        private void Move(ref UfoMovementComponent ufoMovementComponent)
        {
            if (ufoMovementComponent.targetMovement == default)
                ufoMovementComponent.targetMovement = GetNextPoint();
            
            var ufo = ufoMovementComponent.ufo;
            var nextPoint = ufoMovementComponent.targetMovement;

            if (Vector3.Distance(ufo.transform.position, nextPoint) > 1f)
            {
                var speed = Random.Range(_ufoSettings.MinSpeed, _ufoSettings.MaxSpeed);
                var speedMultiplier = (int) ufo.UfoType;
                var recalculedSpeed = speed * speedMultiplier / 100;

                ufo.transform.position = Vector3.Lerp(ufo.transform.position, nextPoint, Time.deltaTime * recalculedSpeed);
                return;
            }

            ufoMovementComponent.targetMovement = GetNextPoint();
            // Shoot();
        }
        
        private Vector3 GetNextPoint()
        {
            var mainCamera = Camera.main;
            var boundHeight = mainCamera.orthographicSize;
            var boundWidth = boundHeight * mainCamera.aspect;
            
            var startPosX = Random.Range(-boundWidth, boundWidth);
            var startPosY = Random.Range(-boundHeight, boundHeight);

            var nextPoint = new Vector3(startPosX, startPosY, 0);
            
            return nextPoint;
        }
    }
}