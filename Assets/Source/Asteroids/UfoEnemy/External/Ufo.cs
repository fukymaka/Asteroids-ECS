using System;
using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;

namespace AsteroidsECS
{
    public class Ufo : Actor
    {
        public override ActorType ActorType { get; } = ActorType.Ufo;
        public override PossibleCollisions PossibleCollisions { get; } = PossibleCollisions.Asteroid | PossibleCollisions.Player | PossibleCollisions.PlayerProjectile;
        public UfoType UfoType { get; set; }
    }
}