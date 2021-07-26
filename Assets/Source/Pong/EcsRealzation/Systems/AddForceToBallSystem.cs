using Leopotam.Ecs;
using UnityEngine;

namespace Source.Systems
{
    public class AddForceToBallSystem : IEcsInitSystem
    {
        private readonly PongEnvironment _pongEnvironment = null;
        
        public void Init()
        {
            var rigidbody2d = _pongEnvironment.Ball.GetComponent<Rigidbody2D>();
            var direction = new Vector2(Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized;
            rigidbody2d.AddForce(direction * 1000);
        }
    }
}