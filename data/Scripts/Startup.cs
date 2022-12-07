using Leopotam.EcsLite;
using ProjectRed.Initiables;
using System;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "ab233cb5e516269075fc48afd84b5e42744308b9")]
public class Startup : Component
{
    private EcsWorld _world;
    private EcsSystems _systems;

    public Action<EcsWorld, EcsSystems> Initialized { get; set; }

    private void Init()
    {
        _world = new();
        _systems = new(_world);

        SubscribeInitiables();
        Initialized?.Invoke(_world, _systems);

        _systems.Init();
    }

    private void SubscribeInitiables()
    {
        var initiables = node.GetComponents<Initiable>();

        foreach (var initiable in initiables)
        {
            Initialized += initiable.Initialize;
        }
    }

    private void Update()
    {
        _systems.Run();
    }

    private void Shutdown()
    {
        _world.Destroy();
        _systems.Destroy();
    }
}
