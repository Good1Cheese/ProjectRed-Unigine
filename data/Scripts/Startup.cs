using Leopotam.EcsLite;
using System;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "ab233cb5e516269075fc48afd84b5e42744308b9")]
public class Startup : Component
{
    [ShowInEditor]
    private AssetLinkNode _player;

    private EcsWorld _world;

    public Action<EcsWorld> Inited { get; set; }

    private void Init()
    {
        _world = new();

        var player = _player.Load(vec3.UP);
        player.GetComponent<IEntity>().Create(_world);
    }


    private void Shutdown()
    {
        _world.Destroy();
    }
}
