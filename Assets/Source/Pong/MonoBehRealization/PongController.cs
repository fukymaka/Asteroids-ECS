using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Source
{
    public class PongController : MonoBehaviour
    {
        public Transform ball;
        public Transform platform1;
        public Transform platform2;

        private float _maxPosition = 2;
        private float _minPosition = -2;

        private Vector2 _direction;

        private void Start()
        {
            _direction = new Vector2(Random.Range(0f, 360f), Random.Range(0f, 360f)).normalized;
            MoveBall();
        }

        private void Update()
        {
            MovePlatform();
            // MoveBall();
        }

        private void MoveBall()
        {
            var rigidbody2d = ball.GetComponent<Rigidbody2D>();
            rigidbody2d.AddForce(_direction * 1000);
        }

        private void MovePlatform()
        {
            var vertical = Input.GetAxis("Vertical") * 0.1f;

            var position = platform1.position;
            position.y += vertical;

            if (position.y > _maxPosition)
                position.y += _maxPosition - position.y;

            if (position.y < _minPosition)
                position.y += _minPosition - position.y;
            
            platform1.position = position;
            position.x += 16;
            platform2.position = position;
        }
    }
}