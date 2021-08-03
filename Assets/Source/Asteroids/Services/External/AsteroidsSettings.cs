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

        public Asteroid GetAsteroidPrefab(int asteroidGeneration)
        {
            switch (asteroidGeneration)
            {
                case 1:
                    return asteroidPrefabFirstGen;
                case 2:
                    return asteroidPrefabSecondGen;
                case 3:
                    return asteroidPrefabThirdGen;
                default:
                    Debug.Log("Generation doesn't exist!");
                    return null;
            }
        }
    }
}