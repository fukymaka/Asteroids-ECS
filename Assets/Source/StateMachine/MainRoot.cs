using System.Collections;
using System.Collections.Generic;
using AsteroidsECS;
using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using Source.StateMachine;
using UnityEngine;
using UnityEngine.UI;

public class MainRoot : MonoBehaviour
{
    [SerializeField] private ThemeSelectButton themeSelectButtons;
    [SerializeField] private LessonSelectButton lessonSelectButtons;
    [SerializeField] private StepsButton stepsButtons;
    [SerializeField] private Transform buttonContainer;
    [SerializeField] private Theme theme;
    
    private EcsWorld _world;
    private EcsSystems _updateSystems;
    private Context _context;

    public EcsWorld GetWorld()
    {
        return _world;
    }

    public void SetThemeSelectWorld()
    {
        _world?.Destroy();
        _updateSystems?.Destroy();

        _world = new EcsWorld();

        _updateSystems = new EcsSystems(_world)
            .Add(new OnThemeScreenSystem())
            .Inject(themeSelectButtons);
        
        GeneralInitWorld();
        _updateSystems.Init();
    }
    
    public void SetLessonSelectWorld()
    {
        _world?.Destroy();
        _updateSystems?.Destroy();
        
        _world = new EcsWorld();

        _updateSystems = new EcsSystems(_world)
            .Add(new OnLessonSelectSystem())
            .Inject(lessonSelectButtons);
        
        GeneralInitWorld();
        _updateSystems.Init();
    }
    
    public void SetStepsWorld()
    {
        _world?.Destroy();
        _updateSystems?.Destroy();
        
        _world = new EcsWorld();

        _updateSystems = new EcsSystems(_world)
            .Add(new OnStepsSystem())
            .Inject(stepsButtons);
        
        GeneralInitWorld();
        _updateSystems.Init();
    }

    private void GeneralInitWorld()
    {
        _updateSystems
            .Inject(_context)
            .Inject(buttonContainer)
            .Inject(theme);
        
#if UNITY_EDITOR
        EcsWorldObserver.Create(_world);
        EcsSystemsObserver.Create(_updateSystems);
#endif
    }

    private void Awake()
    {
        _context = new Context(this);
        _context.TransitTo(new ThemeSelectState());
    }

    private void Update()
    {
        _updateSystems.Run();
    }

    private void OnDestroy()
    {
        _updateSystems.Destroy();
        _world.Destroy();
    }
}
