using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class AsteroidMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidComponent, AsteroidSpawnRequest> _asteroidFilter = null;
        
        public void Run()
        {
            if (_asteroidFilter.IsEmpty())
                return;

            foreach (var index in _asteroidFilter)
            {
                ref var asteroidComponent = ref _asteroidFilter.Get1(index);

                if (asteroidComponent.IsInit) 
                    continue;
                
                var asteroid = asteroidComponent.Asteroid;
                var speed = asteroidComponent.Speed;
                var rigidbody = asteroid.GetComponent<Rigidbody2D>();
                asteroidComponent.IsInit = true;
                
                rigidbody.AddForce(asteroid.transform.up * speed);
            }
        }
    }
}