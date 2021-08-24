using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

namespace AsteroidsECS
{
    [Serializable]
    public class UiEnvironment 
    {
        [SerializeField] private StartScreenUi startScreenUi;
        [SerializeField] private GameScreenUi gameScreenUi;
        [SerializeField] private LoseScreenUi loseScreenUi;

        public StartScreenUi StartScreenUi => startScreenUi;
        public GameScreenUi GameScreenUi => gameScreenUi;
        public LoseScreenUi LoseScreenUi => loseScreenUi;
    }
}