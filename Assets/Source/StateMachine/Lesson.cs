using System.Collections.Generic;
using UnityEngine;

namespace Source.StateMachine
{
    [CreateAssetMenu]
    public class Lesson : ScriptableObject
    {
        public int lessonId;
        public List<Step> steps;
        
    }
}