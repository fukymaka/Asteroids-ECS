using AsteroidsECS.Services.Enums;
using UnityEngine;

namespace AsteroidsECS.Services.Abstracts
{
    public abstract class Actor : MonoBehaviour
    {
        public abstract ActorType ActorType { get;}
        public abstract PossibleCollisions PossibleCollisions { get; }
    }
}