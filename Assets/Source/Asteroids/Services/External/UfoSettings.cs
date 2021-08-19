using UnityEngine;

namespace AsteroidsECS
{
    [CreateAssetMenu]
    public class UfoSettings : ScriptableObject
    {
        [SerializeField] private Ufo ufoFirstType;
        [SerializeField] private Ufo ufoSecondType;
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;
        [SerializeField] private UfoProjectile projectilePrefab;
        [SerializeField] private int ufoIntervalSpawn;

        public UfoProjectile ProjectilePrefab => projectilePrefab;
        public int UfoIntervalSpawn => ufoIntervalSpawn;
        public float MinSpeed => minSpeed;
        public float MaxSpeed => maxSpeed;

        public Ufo GetUfoPrefab(UfoType ufoType)
        {
            switch (ufoType)
            {
                case UfoType.First:
                    return ufoFirstType;
                case UfoType.Second:
                    return ufoSecondType;
                default:
                    Debug.Log("Ufo type doesn't exist!");
                    return null;
            }
        }
    }
}