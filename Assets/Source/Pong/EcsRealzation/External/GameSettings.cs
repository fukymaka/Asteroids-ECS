using UnityEngine;

namespace Source
{
    [CreateAssetMenu(menuName = nameof(GameSettings))]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private float minPosition;
        [SerializeField] private float maxPosition;

        public float MinPosition => minPosition;
        public float MaxPosition => maxPosition;
    }
}