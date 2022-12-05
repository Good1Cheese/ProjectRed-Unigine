using Leopotam.EcsLite;
using Unigine;

[Component(PropertyGuid = "6585e2fde7614838cc9dee37d0bcf62a2a362f81")]
public class PlayerInit : Component, IInitializable
{
    [ShowInEditor]
    private AssetLinkNode _player;

    public void Init(EcsWorld world, EcsSystems systems)
    {
        Node node = _player.Load(vec3.UP, quat.IDENTITY);
    }
}
