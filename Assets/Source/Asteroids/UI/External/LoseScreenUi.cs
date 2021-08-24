using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AsteroidsECS
{
    public class LoseScreenUi : MonoBehaviour
    {
        [SerializeField] private Text textOnLoseScreen;
        public Text TextOnLoseScreen => textOnLoseScreen;
    }
}