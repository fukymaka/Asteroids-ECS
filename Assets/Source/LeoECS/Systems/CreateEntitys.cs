using Leopotam.Ecs;
using Source.LeoECS.Components;

namespace Source.LeoECS.Systems
{
    public class CreateEntitys : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        
        public void Init()
        {
            var entity = _world.NewEntity();
            
            ref var _text = ref entity.Get<TextComponent>().Text;
            _text = "kkekke";
            
            var entity2 = _world.NewEntity();
            
            ref var _text2 = ref entity2.Get<TextComponent>().Text;
            _text2 = "хуууй";
        }
    }
}