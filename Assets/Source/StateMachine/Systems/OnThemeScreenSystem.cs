using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Source.StateMachine
{
    public class OnThemeScreenSystem : IEcsInitSystem
    {
        private readonly ThemeSelectButton _themeSelectButtons = null;
        private readonly Transform _buttonsContainer = null;
        private readonly Context _context = null;
        private readonly Theme _theme = null;
        
        public void Init()
        {
            var button = Object.Instantiate(_themeSelectButtons, _buttonsContainer).GetComponent<Button>();
            var transform = button.transform;
            var posButton = transform.position;
            transform.position = posButton;
                
            button.GetComponentInChildren<Text>().text = $"Theme 1";

            button.onClick.AddListener(() =>
            {
                _context.CurrentTheme = _theme;
                _context.TransitTo(new LessonSelectState());
            });
            Debug.Log("On theme screen");
        }
    }
}