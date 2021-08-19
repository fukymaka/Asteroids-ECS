using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;
using AsteroidsECS.Services.Interfaces;
using UnityEngine;

namespace AsteroidsECS
{
    public class Asteroid : Actor
    {
        public override ActorType ActorType { get; } = ActorType.Asteroid;
        public override PossibleCollisions PossibleCollisions { get; } = PossibleCollisions.Player | PossibleCollisions.Ufo | PossibleCollisions.PlayerProjectile;
        public AsteroidGeneration AsteroidGeneration { get; set; } = AsteroidGeneration.First;
    }
}