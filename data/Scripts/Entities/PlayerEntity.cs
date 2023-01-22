using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Rotate;
using ProjectRed.Mechanics.Weapon.Intersection;
using Unigine;
using XorterDI;

namespace ProjectRed.Entities;

[Component(PropertyGuid = "ea5e73a7109e5cda3ec286710ee9cd1c2dc385cb")]
public class PlayerEntity : Component, IEntity
{
    [ShowInEditor]
    private Movement _movement;

    [ShowInEditor]
    private Rotation _rotation;

    [ShowInEditor]
    private IntersectionComponent _interaction;

    [ShowInEditor]
    private PlayerGameObject _player;

    [Inject]
    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        world.Add(entity, _player);
        world.Add(entity, _interaction);
        world.Add(entity, _movement);
        world.Add(entity, _rotation);
    }
}
