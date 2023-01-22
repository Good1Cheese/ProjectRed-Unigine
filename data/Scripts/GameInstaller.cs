using Unigine;
using XorterDI;

namespace ProjectRed;

[Component(PropertyGuid = "c74731648b7e4d7334efb43607ae9e1da42188d8")]
public class GameInstaller : Installer
{
    public override void InstallBindings()
    {
        var spawn = node.GetComponent<EntitySpawn>();
        spawn.Spawn();

        var world = node.GetComponent<EcsWorldHandler>();
        _container.Bind(world.Create());
    }
}
