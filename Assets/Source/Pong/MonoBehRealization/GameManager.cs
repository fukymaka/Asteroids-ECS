using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Source
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;
        public static GameManager Instance => _instance;

        public CanvasGroup canvasGroup;
        public Button reloadButton;
        public TMP_Text scoreText;

        private int _score;
        
        private void Awake()
        {
            _instance = this;
            
            reloadButton.onClick.AddListener(() =>
            {
                Restart();
            });
        }

        public void ShowGameOverMessage()
        {
            canvasGroup.alpha = 1;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddScorePoint()
        {
            _score++;
            scoreText.text = _score.ToString();
        }
    }
}