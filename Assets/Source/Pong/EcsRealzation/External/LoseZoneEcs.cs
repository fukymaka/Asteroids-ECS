using System;
using UnityEngine;

namespace Source
{
    public class LoseZoneEcs : MonoBehaviour
    {
        public event Action OnTriggerEnter;

        private void OnTriggerEnter2D(Collider2D other)
        {
            OnTriggerEnter.Invoke();
        }
    }
}