using System;
using UnityEngine;

namespace Source
{
    public class PlatformEcs : MonoBehaviour
    {
        public event Action OnCollision;

        private void OnCollisionEnter2D(Collision2D other)
        {
            OnCollision.Invoke();
        }
    }
}