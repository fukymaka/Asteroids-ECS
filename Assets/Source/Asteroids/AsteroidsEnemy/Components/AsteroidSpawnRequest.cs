using AsteroidsECS.Services.Enums;
using UnityEngine;

namespace AsteroidsECS
{
    public struct AsteroidSpawnRequest
    {
        public AsteroidGeneration AsteroidGeneration;
        public Vector2 SpawnPosition;
    }
}