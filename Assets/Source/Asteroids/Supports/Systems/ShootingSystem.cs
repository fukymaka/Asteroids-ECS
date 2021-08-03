using System;
using Leopotam.Ecs;
using UnityEngine;
using Object = UnityEngine.Object;

namespace AsteroidsECS
{
    public class ShootingSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<ShootComponent> _shootFilter = null;
        
        private float _boundHeight;
        private float _boundWidth;

        public void Init()
        {
            CalculateBounds();
        }

        public void Run()
        {
            if (_shootFilter.IsEmpty())
                return;

            foreach (var index in _shootFilter)
            {
                var shootRequest = _shootFilter.Get1(index);

                var projectile = shootRequest.Projectile;
                var from = shootRequest.From;
                var to = shootRequest.To;
                var speed = shootRequest.ProjectileSpeed;
            
                var directionProjectile = (to - from).normalized;
                var translationProjectile = directionProjectile * (speed * Time.deltaTime);
                projectile.transform.Translate(translationProjectile);

                if (!CheckExitBounds(projectile.transform)) 
                    continue;
                
                Object.Destroy(projectile.gameObject);
                _shootFilter.GetEntity(index).Destroy();
            }
        }
        
        private void CalculateBounds()
        {
            var mainCamera = Camera.main;
            _boundHeight = mainCamera.orthographicSize;
            _boundWidth = _boundHeight * mainCamera.aspect;
        }

        private bool CheckExitBounds(Transform projectile)
        {
            if (Math.Abs(projectile.position.y) > _boundHeight)
                return true;

            if (Math.Abs(projectile.position.x) > _boundWidth)
                return true;

            return false;
        }
    }
}