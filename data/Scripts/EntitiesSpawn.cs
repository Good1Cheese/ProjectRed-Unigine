using ProjectRed;
using Unigine;

namespace ProjectRed;

[Component(PropertyGuid = "83316764ade70b733df55a36f31c0c1df0841ed8")]
public class EntitiesSpawn : Component
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
