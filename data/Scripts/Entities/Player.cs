using Leopotam.EcsLite;
using ProjectRed.Entities;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Move;
using ProjectRed.Mechanics.Object;
using ProjectRed.Mechanics.Rotate;
using Unigine;

[Component(PropertyGuid = "98b346d4567604230d7e1b26d15d784ddba1bd48")]
public class PlayerEntity : Component, IEntity
{
    [ShowInEditor]
    private Movement _movement;

    [ShowInEditor]
    private Rotation _rotation;

    [ShowInEditor]
    private Intersection _interaction;

    [ShowInEditor]
    private GameObject _gameObject;

    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        world.Add(entity, _gameObject);
        world.Add(entity, _interaction);
        world.Add(entity, _movement);
        world.Add(entity, _rotation);
    }
}
