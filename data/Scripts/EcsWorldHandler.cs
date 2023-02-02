using Leopotam.EcsLite;
using ProjectRed;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "b518793a05a437515ab9087c6551c9aba9a3530e")]
public class EcsWorldHandler : Component
{
    private EcsWorld _world;

    public EcsWorld Create()
    {
        _world = new EcsWorld();

        var systems = node.GetComponent<EcsSystemsHandler>();
        systems.Create(_world);

        return _world;
    }

    private void Shutdown()
    {
        _world.Destroy();
    }
}
