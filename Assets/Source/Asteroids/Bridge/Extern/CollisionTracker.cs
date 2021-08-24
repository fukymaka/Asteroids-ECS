using System;
using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Interfaces;
using Leopotam.Ecs;
using UnityEngine;

namespace AsteroidsECS
{
    public class CollisionTracker : MonoBehaviour
    {
        private CollisionUnityBridge _collisionBridge;

        private void Start()
        {
            _collisionBridge = FindObjectOfType<CollisionUnityBridge>();
        }
    
        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (!TryGetComponent(out Actor initiator)) 
                return;
            
            if (collider.TryGetComponent(out Actor injured))
                _collisionBridge.CreateRequest(initiator, injured);
        }
    }
}