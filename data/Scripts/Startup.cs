using Leopotam.EcsLite;
using ProjectRed.Entities;
using System;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "ab233cb5e516269075fc48afd84b5e42744308b9")]
public class Startup : Component
{
    [ShowInEditor]
    private Systems _systems;

    [ShowInEditor]
    private Component[] _initiables;

    private EcsWorld _world;

    public Action<EcsWorld> Inited { get; set; }

    private void Init()
    {
        _world = new();
        _systems.Initialize(_world);

        InvokeEvent();  
    }

    private void InvokeEvent()
    {
        foreach (var initiable in _initiables)
        {
            var init = (IEntity)initiable;
            Inited += init.Create;
        }

        Inited?.Invoke(_world);
    }

    private void Shutdown()
    {
        _world.Destroy();
    }
}
