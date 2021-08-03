using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Source.StateMachine
{
    public class OnStepsSystem : IEcsInitSystem
    {
        private readonly StepsButton _stepsButton = null;
        private readonly Transform _buttonsContainer = null;
        private readonly Context _context = null;
        private readonly Theme _theme = null;

        public void Init()
        {
            var padding = 0;
            
            foreach (var step in _context.CurrentLesson.steps)
            {
                var button = Object.Instantiate(_stepsButton, _buttonsContainer).GetComponent<Button>();
                var transform = button.transform;
                var posButton = transform.position;
                posButton.y += 50 * padding;
                transform.position = posButton;

                button.GetComponentInChildren<Text>().text = $"Lesson {_context.CurrentLesson.lessonId}, Step {step.StepId}";

                
                if (padding == 0)
                {
                    button.onClick.AddListener(() =>
                    {
                        var lesson = _context.CurrentLesson;
                        _context.CurrentLesson = _theme.lessons[lesson.lessonId - 2];
                        _context.TransitTo(new StepsState());
                    });
                }

                if (padding == 3)
                {
                    button.onClick.AddListener(() =>
                    {
                        var lesson = _context.CurrentLesson;
                        _context.CurrentLesson = _theme.lessons[lesson.lessonId];
                        _context.TransitTo(new StepsState());
                    });
                }

                padding++;
            }

            Debug.Log("On steps");
        }
    }
}