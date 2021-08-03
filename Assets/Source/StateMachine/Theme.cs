using System.Collections.Generic;
using UnityEngine;

namespace Source.StateMachine
{
    [CreateAssetMenu]
    public class Theme : ScriptableObject
    {
        public int themeId;
        public List<Lesson> lessons;
    }
}