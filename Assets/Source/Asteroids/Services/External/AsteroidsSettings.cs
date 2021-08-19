using AsteroidsECS.Services.Enums;
using UnityEngine;

namespace AsteroidsECS
{
    [CreateAssetMenu(fileName = "Asteroids_Settings")]
    public class AsteroidsSettings : ScriptableObject
    {
        [SerializeField] private Asteroid asteroidPrefabFirstGen;
        [SerializeField] private Asteroid asteroidPrefabSecondGen;
        [SerializeField] private Asteroid asteroidPrefabThirdGen;
        [SerializeField] private float speed;
        // [SerializeField] private float maxStartSpeed;

        // public Asteroid AsteroidPrefabFirstGen => asteroidPrefabFirstGen;
        //
        // public Asteroid AsteroidPrefabSecondGen => asteroidPrefabSecondGen;
        //
        // public Asteroid AsteroidPrefabThirdGen => asteroidPrefabThirdGen;

        public float Speed => speed;

        // public float MAXStartSpeed => maxStartSpeed;

        public Asteroid GetAsteroidPrefab(AsteroidGeneration asteroidGeneration)
        {
            switch (asteroidGeneration)
            {
                case AsteroidGeneration.First:
                    return asteroidPrefabFirstGen;
                case AsteroidGeneration.Second:
                    return asteroidPrefabSecondGen;
                case AsteroidGeneration.Third:
                    return asteroidPrefabThirdGen;
                default:
                    Debug.Log("Generation doesn't exist!");
                    return null;
            }
        }
    }
}