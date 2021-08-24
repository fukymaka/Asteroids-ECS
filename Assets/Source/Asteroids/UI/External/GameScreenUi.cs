using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsECS
{
    public class GameScreenUi : MonoBehaviour
    {
        [SerializeField] private Text hightScore;
        [SerializeField] private Text currentScore;
        [SerializeField] private Text currentRound;
        [SerializeField] private Transform healthAnchor;
        [SerializeField] private Image healthIcon;

        public Text HightScore => hightScore;
        public Text CurrentScore => currentScore;
        public Text CurrentRound => currentRound;
        public Image HealthIcon => healthIcon;
        public Transform HealthAnchor => healthAnchor;
    }
}