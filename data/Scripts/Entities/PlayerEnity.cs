using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Intersection;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Rotate;
using Unigine;
using XorterDI;

namespace ProjectRed.Entities;

[Component(PropertyGuid = "808d35ed4b3c1e68fac1eea78bad9bdab8a2b971")]
public class PlayerEntity : Component, IEntity
{
    [ShowInEditor]
    private Mechanics.Object.Player _player;

    [ShowInEditor]
    private GameObject _gameObject;

    [ShowInEditor]
    private Bullet _bullet;

    [ShowInEditor]
    private Movement _movement;

    [ShowInEditor]
    private Rotation _rotation;

    [ShowInEditor]
    private IntersectionComponent _interaction;

    [Inject]
    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        world.Add(entity, _player);
        world.Add(entity, _gameObject);
        world.Add(entity, _bullet);
        world.Add(entity, _movement);
        world.Add(entity, _rotation);
        world.Add(entity, _interaction);
    }
}
