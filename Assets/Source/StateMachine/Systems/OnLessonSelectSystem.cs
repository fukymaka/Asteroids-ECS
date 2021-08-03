using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Source.StateMachine
{
    public class OnLessonSelectSystem : IEcsInitSystem
    {
        private readonly LessonSelectButton _lessonSelectButtons = null;
        private readonly Transform _buttonsContainer = null;
        private readonly Context _context = null;
        private readonly Theme _theme = null;
        
        public void Init()
        {
            var padding = 0;
            
            foreach (var lesson in _context.CurrentTheme.lessons)
            {
                var button = Object.Instantiate(_lessonSelectButtons, _buttonsContainer).GetComponent<Button>();
                var transform = button.transform;
                var posButton = transform.position;
                posButton.y += 50 * padding;
                transform.position = posButton;

                button.onClick.AddListener(() =>
                {
                    _context.CurrentLesson = lesson;
                    _context.TransitTo(new StepsState());
                });
                
                button.GetComponentInChildren<Text>().text = $"Theme {_context.StepId.x}, Lesson {lesson.lessonId}";

                padding++;
            }
            
            Debug.Log("On lesson select screen");
        }
    }
}