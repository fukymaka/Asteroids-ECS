using UnityEngine;

namespace AsteroidsECS
{
    public struct ShootComponent
    {
        public PlayerProjectile PlayerProjectile;
        public Vector2 From;
        public Vector2 To;
        public float ProjectileSpeed;
    }
}