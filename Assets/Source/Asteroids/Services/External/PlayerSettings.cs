using UnityEngine;

namespace AsteroidsECS
{
    [CreateAssetMenu(fileName = "Player_Settings")]
    public class PlayerSettings : ScriptableObject
    {
        [SerializeField] private Player playerPrefab;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private PlayerProjectile playerProjectilePrefab;
        [SerializeField] private float projectileSpeed;

        public Player PlayerPrefab => playerPrefab;

        public float MinSpeed => minSpeed;

        public float MaxSpeed => maxSpeed;

        public float RotationSpeed => rotationSpeed;

        public PlayerProjectile PlayerProjectilePrefab => playerProjectilePrefab;

        public float ProjectileSpeed => projectileSpeed;
    }
}