using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Rotate;
using Unigine;

namespace ProjectRed.Initiables.Entities;

[Component(PropertyGuid = "6585e2fde7614838cc9dee37d0bcf62a2a362f81")]
public class Player : Component, Initiable
{
    [ShowInEditor]
    private AssetLinkNode _nodeLink;

    [ShowInEditor]
    private Movement _movement;

    [ShowInEditor]
    private Rotation _rotation;

    private GameObject _gameObject;


    public void Initialize(EcsWorld world, EcsSystems systems)
    {
        Node node = _nodeLink.Load(vec3.UP);
        var camera = node.GetChild(0) as PlayerDummy;

        int entity = world.NewEntity();

        _gameObject = new(node, camera);

        world.Add(entity, _gameObject);
        world.Add(entity, _movement);
        world.Add(entity, _rotation);
    }
}
