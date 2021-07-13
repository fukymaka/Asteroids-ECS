using Leopotam.Ecs;
using Source.LeoECS.Components;
using UnityEngine;
using UnityEngine.UI;

namespace Source.LeoECS.Systems
{
    public class PrintSystem : IEcsRunSystem
    {
        private readonly EcsFilter<TextComponent> _filter = null;

        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var component = ref _filter.Get1(index);
                Debug.Log(component.Text);
            }
        }
    }
}