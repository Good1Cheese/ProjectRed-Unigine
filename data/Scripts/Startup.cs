using Leopotam.EcsLite;
using ProjectRed.Entities;
using System;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "ab233cb5e516269075fc48afd84b5e42744308b9")]
public class Startup : Component
{
    [ShowInEditor]
    private Component[] _entities;

    [ShowInEditor]
    private AssetLinkNode _player;

    private EcsWorld _world;

    public Action<EcsWorld> Inited { get; set; }

    private void Init()
    {
        _world = new();

        var systems = node.GetComponent<Systems>();
        systems.Initialize(_world);

        var player = _player.Load(vec3.UP);
        Inited += player.GetComponent<IEntity>().Create;

        InvokeEvent();  
    }

    private void InvokeEvent()
    {
        foreach (var entity in _entities)
        {
            Inited += (entity as IEntity).Create;
        }

        Inited?.Invoke(_world);
    }

    private void Shutdown()
    {
        _world.Destroy();
    }
}
