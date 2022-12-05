using Leopotam.EcsLite;
using Unigine;

[Component(PropertyGuid = "6585e2fde7614838cc9dee37d0bcf62a2a362f81")]
public class Player : Component, Initiable
{
    [ShowInEditor]
    private AssetLinkNode _nodeLink;

    [ShowInEditor]
    private Movement _movement;

    public void Initialize(EcsWorld world, EcsSystems systems)
    {
        Node node = _nodeLink.Load(vec3.UP, quat.IDENTITY);

        int entity = world.NewEntity();
        _movement.Node = node;
        world.Add(entity, _movement);
    }
}
