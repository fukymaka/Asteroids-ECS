using AsteroidsECS.CollisionBridge.Components;
using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Interfaces;
using Leopotam.Ecs;
using UnityEngine;
using Zun010.LeoEcsExtensions;

namespace AsteroidsECS
{
    public class CollisionUnityBridge : MonoBehaviour
    {
        private EcsWorld _world;

        public void SetWorld(EcsWorld world)
        {
            _world = world;
        }

        public void CreateRequest(Actor initiator ,Actor injured)
        {
            var collisionEnterRequest = new CollisionEnterRequest
            {
                Initiator = initiator,
                Injured = injured
            };
            _world.NewEntityWith(collisionEnterRequest);
        }
    }
}