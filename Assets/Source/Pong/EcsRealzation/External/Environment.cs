using System;
using TMPro;
using UnityEngine;

namespace Source
{
    public class Environment : MonoBehaviour
    {
        [SerializeField] private PlatformEcs platform1;
        [SerializeField] private PlatformEcs platform2;
        [SerializeField] private LoseZoneEcs loseZone1;
        [SerializeField] private LoseZoneEcs loseZone2;
        [SerializeField] private Transform ball;
        [SerializeField] private Canvas canvasEnvironment;

        public PlatformEcs Platform1 => platform1;
        public PlatformEcs Platform2 => platform2;

        public LoseZoneEcs LoseZone1 => loseZone1;

        public LoseZoneEcs LoseZone2 => loseZone2;

        public Transform Ball => ball;

        public Canvas CanvasEnvironment => canvasEnvironment;

        [Serializable]
        public class Canvas
        {
            [SerializeField] private TMP_Text scoreText;
            [SerializeField] private CanvasGroup canvasGroup;

            public TMP_Text ScoreText => scoreText;

            public CanvasGroup CanvasGroup => canvasGroup;
        }
    }
}