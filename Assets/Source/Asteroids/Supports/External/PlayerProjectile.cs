using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;
using AsteroidsECS.Services.Interfaces;
using UnityEngine;

namespace AsteroidsECS
{
    public class PlayerProjectile : Actor
    {
        public override ActorType ActorType { get; } = ActorType.PlayerProjectile;
        public override PossibleCollisions PossibleCollisions { get; } = PossibleCollisions.Asteroid | PossibleCollisions.Ufo;
    }
}