using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "04e16e9b1b16533ea2c9e185f687652093b9d5ff")]
public class EntitySpawn : Component
{
    [ShowInEditor]
    private SpawnableEntity[] _entities;

    public void Spawn()
    {
        foreach (var entity in _entities)
        {
            entity.NodeLink.Load(entity.Position,
                                 entity.Rotation);
        }
    }
}
