using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;

namespace AsteroidsECS
{
    public class UfoProjectile : Actor
    {
        public override ActorType ActorType { get; } = ActorType.UfoProjectile;
        public override PossibleCollisions PossibleCollisions { get; } = PossibleCollisions.Asteroid | PossibleCollisions.Player;
    }
}