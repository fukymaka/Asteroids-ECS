using AsteroidsECS.Services.Enums;
using UnityEngine;

namespace AsteroidsECS.Services.Interfaces
{
    public interface IActor
    {
        ActorType ActorType { get;}
        PossibleCollisions PossibleCollisions { get; }
        GameObject GetActor();

    }
}