using UnityEngine;

namespace AsteroidsECS
{
    public struct ShootComponent
    {
        public Projectile Projectile;
        public Vector2 From;
        public Vector2 To;
        public float ProjectileSpeed;
    }
}