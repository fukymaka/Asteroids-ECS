using AsteroidsECS.CollisionBridge.Components;
using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;
using AsteroidsECS.Services.Interfaces;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class DestroyerSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<CollisionEnterRequest> _collisionEnterFilter = null;

        public void Run()
        {
            if (_collisionEnterFilter.IsEmpty())
                return;

            var collisionEnterRequest = _collisionEnterFilter.Get1(0);
            _collisionEnterFilter.GetEntity(0).Destroy();

            var initator = collisionEnterRequest.Initiator;
            var injured = collisionEnterRequest.Injured;

            if (initator.ActorType is ActorType.Asteroid)
                ProcessAsteroidCollision((Asteroid) initator, injured);
            else
                ProcessCollision(initator, injured);
        }

        private void ProcessCollision(Actor initiator, Actor injured)
        {
            var initiatorPossibleCollisions = initiator.PossibleCollisions;
            var injuredActorType = (PossibleCollisions) injured.ActorType;

            if (initiatorPossibleCollisions.HasFlag(injuredActorType))
            {
                // Object.Instantiate(prefabsHolder.Explosion, initiator.transform.position, Quaternion.identity);
                Object.Destroy(initiator.gameObject);
            }
        }

        private void ProcessAsteroidCollision(Asteroid initiator, Actor injured)
        {
            var initiatorPossibleCollisions = initiator.PossibleCollisions;
            var injuredActorType = (PossibleCollisions) injured.ActorType;

            if (!initiatorPossibleCollisions.HasFlag(injuredActorType)) 
                return;

            var asteroidSpawnRequest = new AsteroidSpawnRequest();
            asteroidSpawnRequest.SpawnPosition = initiator.transform.position;
            

            switch (initiator.AsteroidGeneration)
            {
                case AsteroidGeneration.First:
                    asteroidSpawnRequest.AsteroidGeneration = AsteroidGeneration.Second;
                    _world.NewEntityWith(asteroidSpawnRequest);
                    _world.NewEntityWith(asteroidSpawnRequest);
                    break;
                case AsteroidGeneration.Second:
                    asteroidSpawnRequest.AsteroidGeneration = AsteroidGeneration.Third;
                    _world.NewEntityWith(asteroidSpawnRequest);
                    _world.NewEntityWith(asteroidSpawnRequest);
                    break;
            }
            // HighScore.AddAsteroidPoints(initiator);
            Object.Destroy(initiator.gameObject);
            // Object.Instantiate(prefabsHolder.Explosion, initiator.transform.position, Quaternion.identity);
        }
    }
}