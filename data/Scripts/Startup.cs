using Leopotam.EcsLite;
using System;
using Unigine;

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

        SubscribeInitials();
        Initialized?.Invoke(_world, _systems);

        _systems.Init();
    }

    private void SubscribeInitials()
    {
        var entitySpawners = node.GetComponents<IInitializable>();

        foreach (var spawn in entitySpawners)
        {
            Initialized += spawn.Init;
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
