using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class PlayerShootingSystem : IEcsRunSystem
    {
        private readonly PlayerSettings _playerSettings = null;
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerComponent> _playerFilter = null;

        public void Run()
        {
            if (_playerFilter.IsEmpty())
                return;
            
            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }

        private void Shoot()
        {
            var playerComponent = _playerFilter.Get1(0);
            var player = playerComponent.Player;
            var projectile = _playerSettings.PlayerProjectilePrefab;
            var projectileSpeed = _playerSettings.ProjectileSpeed;

            projectile = Object.Instantiate(projectile, player.transform.position, Quaternion.identity);

            var shootRequest = new ShootComponent
            {
                PlayerProjectile = projectile,
                From = projectile.transform.position,
                To = player.transform.up + player.transform.position,
                ProjectileSpeed = projectileSpeed,
            };
            var projectileEntity = _world.NewEntityWith(shootRequest);
        }
    }
}