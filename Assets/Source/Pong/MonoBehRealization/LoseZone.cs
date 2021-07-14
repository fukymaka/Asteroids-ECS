using System;
using UnityEngine;

namespace Source
{
    public class LoseZone : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag != "Player")
                return;
            
            GameManager.Instance.ShowGameOverMessage();
        }
    }
}