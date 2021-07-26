using UnityEngine;

namespace Source
{
    [CreateAssetMenu(menuName = nameof(PongGameSettings))]
    public class PongGameSettings : ScriptableObject
    {
        [SerializeField] private float minPosition;
        [SerializeField] private float maxPosition;

        public float MinPosition => minPosition;
        public float MaxPosition => maxPosition;
    }
}