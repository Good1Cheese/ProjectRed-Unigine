using Unigine;
using XorterDI;

namespace ProjectRed;

[Component(PropertyGuid = "05888544ed1acfd341349316dbdb2f7d5eb12ab8")]
public class GameInstaller : Installer
{
    public override void InstallBindings()
    {
        var spawn = node.GetComponent<EntitiesSpawn>();
        spawn.Spawn();

        var world = node.GetComponent<EcsWorldHandler>();
        _container.Bind(world.Create());
    }
}
