using AsteroidsECS.Services.Abstracts;
using AsteroidsECS.Services.Enums;
using UnityEngine;

namespace AsteroidsECS
{
    public class Player : Actor
    {
        public override ActorType ActorType { get; } = ActorType.Player;

        public override PossibleCollisions PossibleCollisions { get; } = PossibleCollisions.Asteroid |
                                                                         PossibleCollisions.Ufo |
                                                                         PossibleCollisions.UfoProjectile;
    }
}