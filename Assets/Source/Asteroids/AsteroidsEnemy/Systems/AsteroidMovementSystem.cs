using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class AsteroidMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<AsteroidMovementRequest> _asteroidFilter = null;
        
        public void Run()
        {
            if (_asteroidFilter.IsEmpty())
                return;

            var asteroidMovementRequest = _asteroidFilter.Get1(0);
            
            var asteroid = asteroidMovementRequest.Asteroid;
            var speed = asteroidMovementRequest.Speed;
            var rigidbody = asteroid.GetComponent<Rigidbody2D>();
                
            rigidbody.AddForce(asteroid.transform.up * speed);

            _asteroidFilter.GetEntity(0).Destroy();
        }
    }
}