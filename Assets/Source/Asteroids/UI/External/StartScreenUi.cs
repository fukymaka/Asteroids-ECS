using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsECS
{
    public class StartScreenUi : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Text hightScoreOnMainScreen;

        public Button PlayButton => playButton;
        public Text HightScoreOnMainScreen => hightScoreOnMainScreen;
    }
}