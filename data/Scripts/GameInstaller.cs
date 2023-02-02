using Unigine;
using XorterDI;

namespace ProjectRed;

[Component(PropertyGuid = "48ed6eb75a797caa68e0040135808d6cfbdb29db")]
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
