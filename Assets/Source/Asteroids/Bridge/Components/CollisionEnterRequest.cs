using AsteroidsECS.Services.Abstracts;

namespace AsteroidsECS.CollisionBridge.Components
{
    public struct CollisionEnterRequest
    {
        public Actor Initiator;
        public Actor Injured;
    }
}