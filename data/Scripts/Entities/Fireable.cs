using Leopotam.EcsLite;
using ProjectRed.Extensions;
using ProjectRed.Mechanics.Fireable;
using Unigine;

namespace ProjectRed.Entities;

[Component(PropertyGuid = "16556aacd211e61b81a964be26bac505dbe7f2a0")]
public class Fireable : Component, IEntity
{
    [ShowInEditor]
    private Weapon _weapon;

    public EcsPackedEntity PackedEntity { get; set; }

    public void Create(EcsWorld world)
    {
        int entity = world.NewEntity();

        _weapon.Node = node;

        world.Add(entity, _weapon);

        PackedEntity = world.PackEntity(entity);
    }
}
