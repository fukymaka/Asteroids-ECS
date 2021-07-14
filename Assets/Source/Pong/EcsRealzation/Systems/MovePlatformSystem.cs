using Leopotam.Ecs;
using UnityEngine;

namespace Source.Systems
{
    public class MovePlatformSystem : IEcsRunSystem
    {
        private readonly Environment _environment = null;
        private readonly GameSettings _gameSettings = null;

        public void Run()
        {
            var vertical = Input.GetAxis("Vertical") * 0.1f;
            
            var position = _environment.Platform1.transform.position;
            position.y += vertical;

            var minPosition = _gameSettings.MinPosition;
            var maxPosition = _gameSettings.MaxPosition;
            
            if (position.y > maxPosition)
                position.y += maxPosition - position.y;
            
            if (position.y < minPosition)
                position.y += minPosition - position.y;
            
            _environment.Platform1.transform.position = position;
            position.x += 16;
            _environment.Platform2.transform.position = position;
        }
    }
}