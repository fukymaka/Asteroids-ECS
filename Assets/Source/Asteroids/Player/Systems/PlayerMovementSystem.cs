using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly PlayerSettings _playerSettings = null;
        private readonly EcsFilter<PlayerComponent> _playerFilter = null;
        
        public void Run()
        {
            if (_playerFilter.IsEmpty())
                return;

            var playerComponent = _playerFilter.Get1(0);
            var player = playerComponent.Player;
            Debug.Log(player.transform.position);
            
            var minSpeed = _playerSettings.MinSpeed;
            var maxSpeed = _playerSettings.MaxSpeed;
            var rotationSpeed = _playerSettings.RotationSpeed;
            
            if (!player.TryGetComponent<Rigidbody2D>(out var rigidbody))
                return;

            var force = player.transform.up * minSpeed;
            
            // var currentSpeed = rigidbody.velocity.magnitude;
            // if (currentSpeed > maxSpeed)
            // {
            //     force = Vector3.zero;
            // }

            if (Input.GetKey(KeyCode.W)) 
                rigidbody.AddForce(force);
            
            var rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation *= Time.deltaTime;
            player.transform.Rotate(0, 0, -rotation);
        }
    }
}