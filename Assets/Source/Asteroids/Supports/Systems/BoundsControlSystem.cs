using System;
using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class BoundsControlSystem : IEcsRunSystem, IEcsInitSystem
    {
        private readonly EcsFilter<BoundsComponent> _boundsFilter = null;

        private float _boundHeight;
        private float _boundWidth;

        public void Init()
        {
            CalculateBounds();
        }

        public void Run()
        {
            foreach (var index in _boundsFilter)
            {
                var sender = _boundsFilter.Get1(index).Sender;

                KeepOnScreen(sender);
            }
        }

        private void CalculateBounds()
        {
            var mainCamera = Camera.main;
            _boundHeight = mainCamera.orthographicSize;
            _boundWidth = _boundHeight * mainCamera.aspect;
        }

        private void KeepOnScreen(Transform sender)
        {
            var position = sender.position;

            if (Math.Abs(position.y) > _boundHeight)
            {
                if (position.y > 0)
                    position.y = -_boundHeight;
                else
                    position.y = _boundHeight;
            }

            if (Math.Abs(position.x) > _boundWidth)
            {
                if (position.x > 0)
                    position.x = -_boundWidth;
                else
                    position.x = _boundWidth;
            }

            sender.position = position;
        }
    }
}