using Leopotam.EcsLite;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "5217ecd3109d0c16d55f547d4e250bb81bf3dbb7")]
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
