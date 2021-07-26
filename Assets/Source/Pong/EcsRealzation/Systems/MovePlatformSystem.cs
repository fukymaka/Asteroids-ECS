using Leopotam.Ecs;
using UnityEngine;

namespace Source.Systems
{
    public class MovePlatformSystem : IEcsRunSystem
    {
        private readonly PongEnvironment _pongEnvironment = null;
        private readonly PongGameSettings _pongGameSettings = null;

        public void Run()
        {
            var vertical = Input.GetAxis("Vertical") * 0.1f;
            
            var position = _pongEnvironment.Platform1.transform.position;
            position.y += vertical;

            var minPosition = _pongGameSettings.MinPosition;
            var maxPosition = _pongGameSettings.MaxPosition;
            
            if (position.y > maxPosition)
                position.y += maxPosition - position.y;
            
            if (position.y < minPosition)
                position.y += minPosition - position.y;
            
            _pongEnvironment.Platform1.transform.position = position;
            position.x += 16;
            _pongEnvironment.Platform2.transform.position = position;
        }
    }
}