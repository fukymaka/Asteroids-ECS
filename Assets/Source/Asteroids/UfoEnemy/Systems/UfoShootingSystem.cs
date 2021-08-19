using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class UfoShootingSystem : IEcsRunSystem
    {
        private readonly UfoSettings _ufoSettings = null;
        private readonly EcsWorld _world = null;
        private EcsFilter<UfoShootRequest> _ufoShootFilter = null;
        private EcsFilter<PlayerComponent> _playerFilter = null;
        
        public void Run()
        {
            if (_ufoShootFilter.IsEmpty())
                return;

            var ufo = _ufoShootFilter.Get1(0).Ufo;
            
            if (_playerFilter.IsEmpty())
                return;

            var player = _playerFilter.Get1(0).Player;
            
            Shoot(ufo.transform.position, player.transform.position);
            
            _ufoShootFilter.GetEntity(0).Destroy();
        }
        
        private void Shoot(Vector2 from, Vector2 to)
        {
            var projectile = Object.Instantiate(_ufoSettings.ProjectilePrefab, from, Quaternion.identity);
            var projectileSpeed = _ufoSettings.ProjectileSpeed;

            var shootComponent = new ShootComponent
            {
                Projectile = projectile,
                From = from,
                To = to,
                ProjectileSpeed = projectileSpeed
            };
            _world.NewEntityWith(shootComponent);

            // SoundsComponent.Sounds.PlayUfoShotSound();
        }
    }
}