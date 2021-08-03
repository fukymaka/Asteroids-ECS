using System;
using Leopotam.Ecs;
using UnityEngine;

namespace Source.StateMachine
{
    public class FSM
    {
        
    }

    internal class Context
    {
        private State _state;
        public readonly MainRoot Root;
        public Vector3 StepId;

        public Theme CurrentTheme = null;
        public Lesson CurrentLesson = null;
        public Step CurrentStep = null;

        public Context(MainRoot root)
        {
            Root = root;
            StepId.x = 1;
            StepId.x = 1;
            StepId.x = 1;
        }

        public void TransitTo(State state)
        {
            _state = state;
            _state.SetContext(this);
            _state.SetWorld();
        }
    }

    internal abstract class State
    {
        public Context Context;

        public void SetContext(Context context)
        {
            Context = context;
        }

        public abstract void SetWorld();
    }


    internal class ThemeSelectState : State
    {
        public override void SetWorld()
        {
            Context.Root.SetThemeSelectWorld();
        }
    }

    internal class LessonSelectState : State
    {
        public override void SetWorld()
        {
            Context.Root.SetLessonSelectWorld();
        }
    }
    
    internal class StepsState : State
    {
        public override void SetWorld()
        {
            Context.Root.SetStepsWorld();
        }
    }
    
    internal class OuterStepsState : State
    {
        public override void SetWorld()
        {
        }
    }
}