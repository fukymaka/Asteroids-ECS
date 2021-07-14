using System;
using UnityEngine;

namespace Source
{
    public class Platform : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            GameManager.Instance.AddScorePoint();
        }
    }
}